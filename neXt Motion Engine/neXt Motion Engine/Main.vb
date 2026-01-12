Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks

' Issues may arise if multiple sounds are played simultaneously.
' Issues may also arise if the milisecond duration is very short (less than 20-30ms).
' Currently, it is just a proof of concept.
' Implementation of CDM can be canceled.
' Currently designing how to possibly integrate CDM with neXt Motion Engine.

Public Class XME
    Private Const SampleRate As Integer = 44100

    ' WinAPI function to play sound from memory
    <DllImport("winmm.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function PlaySound(ByVal ptrData As Byte(), ByVal hMod As IntPtr, ByVal flags As Integer) As Boolean
    End Function

    Private Const SND_ASYNC As Integer = &H1      ' Background playback
    Private Const SND_MEMORY As Integer = &H4     ' Send data to RAM
    Private Const SND_NODEFAULT As Integer = &H2  ' No audio if an exception occurs
    Private Const SND_SYNC As Integer = &H0       ' Waiting for playback to finish

    Private Async Function PlayRawDataAsync(samples As Short()) As Task
        If samples Is Nothing OrElse samples.Length = 0 Then Return

        Await Task.Run(Sub()
                           Using ms As New MemoryStream()
                               Using bw As New BinaryWriter(ms)
                                   ' WAV Header
                                   bw.Write("RIFF".ToCharArray())
                                   bw.Write(36 + (samples.Length * 2))
                                   bw.Write("WAVE".ToCharArray())
                                   bw.Write("fmt ".ToCharArray())
                                   bw.Write(16)
                                   bw.Write(CShort(1))
                                   bw.Write(CShort(1))
                                   bw.Write(SampleRate)
                                   bw.Write(SampleRate * 2)
                                   bw.Write(CShort(2))
                                   bw.Write(CShort(16))
                                   bw.Write("data".ToCharArray())
                                   bw.Write(samples.Length * 2)

                                   For Each s In samples
                                       bw.Write(s)
                                   Next

                                   ' Sending audio data to PlaySound
                                   Dim audioData As Byte() = ms.ToArray()
                                   ' Background playback
                                   PlaySound(audioData, IntPtr.Zero, SND_MEMORY Or SND_SYNC Or SND_NODEFAULT)
                               End Using
                           End Using
                       End Sub)
    End Function

    Public Async Function Motion(frequency As Double, durationMs As Integer, volume As Integer) As Task
        Await MotionAcceleration(frequency, frequency, durationMs, volume, volume)
    End Function

    Public Async Function MotionDot(frequency As Double, durationMs As Integer, volume As Integer, repeats As Integer, pauseMs As Integer) As Task
        For i As Integer = 1 To repeats
            Await Motion(frequency, durationMs, volume)
            If i < repeats Then Await Task.Delay(pauseMs)
        Next
    End Function

    Public Async Function MotionAcceleration(startFreq As Double, endFreq As Double, durationMs As Integer, startVol As Integer, endVol As Integer) As Task
        Dim numSamples As Integer = CInt(SampleRate * (durationMs / 1000.0))
        If numSamples < 2 Then numSamples = 2

        Dim samples(numSamples - 1) As Short
        Await Task.Run(Sub()
                           Dim phase As Double = 0
                           For i As Integer = 0 To numSamples - 1
                               Dim progress As Double = i / (numSamples - 1)
                               Dim currentFreq As Double = startFreq + (endFreq - startFreq) * progress
                               Dim amplitude As Double = (startVol + (endVol - startVol) * progress) / 100.0 * Short.MaxValue

                               samples(i) = CShort(amplitude * Math.Sin(phase))
                               phase += 2 * Math.PI * currentFreq / SampleRate
                               If phase > 2 * Math.PI Then phase -= 2 * Math.PI
                           Next
                       End Sub)

        Await PlayRawDataAsync(samples)
    End Function

    Public Async Function MotionPeak(freqA As Double, freqB As Double, freqC As Double, freqD As Double, durationMs As Integer) As Task
        Dim halfDuration As Integer = durationMs \ 2
        Dim numSamplesHalf As Integer = CInt(SampleRate * (halfDuration / 1000.0))
        Dim totalSamples As Integer = numSamplesHalf * 2

        Dim samples(totalSamples - 1) As Short

        Await Task.Run(Sub()
                           Dim phase As Double = 0

                           For i As Integer = 0 To numSamplesHalf - 1
                               Dim progress As Double = i / (numSamplesHalf - 1)
                               Dim currentFreq As Double = freqA + (freqB - freqA) * progress
                               Dim currentVol As Double = 0 + (100 - 0) * progress
                               Dim amplitude As Double = (currentVol / 100.0) * Short.MaxValue

                               samples(i) = CShort(amplitude * Math.Sin(phase))

                               phase += 2 * Math.PI * currentFreq / SampleRate
                               If phase > 2 * Math.PI Then phase -= 2 * Math.PI
                           Next

                           For i As Integer = 0 To numSamplesHalf - 1
                               Dim progress As Double = i / (numSamplesHalf - 1)
                               Dim currentFreq As Double = freqC + (freqD - freqC) * progress
                               Dim currentVol As Double = 100 + (0 - 100) * progress
                               Dim amplitude As Double = (currentVol / 100.0) * Short.MaxValue
                               samples(numSamplesHalf + i) = CShort(amplitude * Math.Sin(phase))

                               phase += 2 * Math.PI * currentFreq / SampleRate
                               If phase > 2 * Math.PI Then phase -= 2 * Math.PI
                           Next
                       End Sub)
        Await PlayRawDataAsync(samples)
    End Function
End Class