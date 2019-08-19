Imports System
Imports System.Drawing
Imports System.Drawing.Imaging


Public Class multitiff


    Public Sub writeMultiTIFF(ByVal fileList As SortedList, ByVal nameMultiTIFF As String)
        Dim gen As New GeneralArchiv
        Try

            If fileList.Count > 0 Then
                Dim multiTIFF As Bitmap
                Dim myImageCodecInfo As ImageCodecInfo
                Dim myEncoder As Encoder
                Dim myEncoderParameter As EncoderParameter
                Dim myEncoderParameters As EncoderParameters

                myImageCodecInfo = GetEncoderInfo("image/tiff")
                myEncoder = Encoder.SaveFlag
                myEncoderParameters = New EncoderParameters(1)

                Dim bFirstPageIsWritten As Boolean = False
                For i As Integer = 0 To fileList.Count - 1
                    Dim file As String = fileList.Item(fileList.GetKey(i))
                    If Not gen.IsNull(file) Then
                        If System.IO.File.Exists(file) Then
                            If Not bFirstPageIsWritten Then
                                'Save the first page (frame).
                                'If System.IO.File.Exists(nameMultiTIFF) Then
                                '    System.IO.File.Delete(nameMultiTIFF)
                                'End If
                                multiTIFF = New Bitmap(file)
                                myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.MultiFrame)
                                myEncoderParameters.Param(0) = myEncoderParameter
                                multiTIFF.Save(nameMultiTIFF, myImageCodecInfo, myEncoderParameters)
                                bFirstPageIsWritten = True
                            Else
                                Dim newPage As Bitmap
                                newPage = New Bitmap(file)
                                myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.FrameDimensionPage)
                                myEncoderParameters.Param(0) = myEncoderParameter
                                multiTIFF.SaveAdd(newPage, myEncoderParameters)
                            End If
                        End If
                    End If
                Next

                'Close the multiple-frame file.
                myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.Flush)
                myEncoderParameters.Param(0) = myEncoderParameter
                multiTIFF.SaveAdd(myEncoderParameters)
                multiTIFF = Nothing
            End If


        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Public Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim gen As New GeneralArchiv
        Try

            Dim j As Integer
            Dim encoders() As ImageCodecInfo
            encoders = ImageCodecInfo.GetImageEncoders()
            For j = 0 To encoders.Length
                If encoders(j).MimeType = mimeType Then
                    Return encoders(j)
                End If
            Next
            Return Nothing

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function


End Class


