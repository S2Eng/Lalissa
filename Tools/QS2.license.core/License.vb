


Public Class License




    Public Shared Function doLicenseFile(ByRef Product As String, ByRef CompanyName As String, ByRef NameComputer As String, _
                                         ByRef StartupPath As String, ByRef SelectedDirectory As String, _
                                         ByRef GeneratedFileNameLicenseFile As String) As Boolean

        Dim UnlockCode As String = Product.Trim() + "." + CompanyName.Trim() + "." + NameComputer.Trim()
        Dim EncryptedUnlockCode As String = License.getEncryptedUnlockCode(Product, CompanyName, NameComputer)
        License.writeLicFile(EncryptedUnlockCode.Trim(), SelectedDirectory, Product, CompanyName, NameComputer, _
                             GeneratedFileNameLicenseFile)
        Return True
    End Function

    Public Shared Function checkLicenseFile(ByRef Path As String, _
                                            ByRef Product As String, ByRef NameComputer As String) As Boolean

        Dim LicenseFile As String = qs2.license.core.License.getLicenseFile(Path, Product, NameComputer)
        If System.IO.File.Exists(LicenseFile) Then

            Dim Encryption1 As New Encryption()
            'Dim EncryptedUnlockCode As String = License.getEncryptedUnlockCode(Product, CompanyName, NameComputer)

            Dim EncryptProductFromApplication As String = Encryption1.StringEncrypt(Product.Trim(), Encryption.keyForEncryptingStrings)
            'Dim EncryptCompanyFromApplication As String = Encryption1.StringEncrypt(CompanyName.Trim(), Encryption.keyForEncryptingStrings)
            Dim EncryptComputerNameFromApplication As String = Encryption1.StringEncrypt(NameComputer.Trim(), Encryption.keyForEncryptingStrings)

            System.GC.Collect()
            Dim StreamReaderLicenseFile As New System.IO.StreamReader(LicenseFile)
            Dim EncryptProductFromLicenseFile = StreamReaderLicenseFile.ReadLine()
            Dim EncryptCompanyFromLicenseFile = StreamReaderLicenseFile.ReadLine()
            Dim EncryptComputerNameFromLicenseFile = StreamReaderLicenseFile.ReadLine()
            StreamReaderLicenseFile.Close()
            System.GC.Collect()

            Dim bAllComputersLicensed As Boolean = False
            Dim DecryptProductFromLicenseFile As String = Encryption1.StringDecrypt(EncryptProductFromLicenseFile.Trim(), Encryption.keyForEncryptingStrings)
            Dim DecryptCompanyFromLicenseFile As String = Encryption1.StringDecrypt(EncryptCompanyFromLicenseFile.Trim(), Encryption.keyForEncryptingStrings)
            Dim DecryptComputerNameFromLicenseFile As String = Encryption1.StringDecrypt(EncryptComputerNameFromLicenseFile.Trim(), Encryption.keyForEncryptingStrings)

            If DecryptProductFromLicenseFile.Trim() = "" Or DecryptCompanyFromLicenseFile.Trim() = "" Or DecryptComputerNameFromLicenseFile.Trim() = "" Then
                Return False
            End If

            If DecryptComputerNameFromLicenseFile.Trim().ToLower() = ("ALL").Trim().ToLower() Then
                bAllComputersLicensed = True
            End If

            If ((Not bAllComputersLicensed) And EncryptProductFromApplication.Trim().ToLower().Equals(EncryptProductFromLicenseFile.Trim().ToLower()) And _
                EncryptComputerNameFromApplication.Trim().ToLower().Equals(EncryptComputerNameFromLicenseFile.Trim().ToLower())) Or _
                (bAllComputersLicensed And _
                EncryptComputerNameFromApplication.Trim().ToLower().Equals(EncryptComputerNameFromLicenseFile.Trim().ToLower())) Then

                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

    Public Shared Function writeLicFile(ByRef EncryptUnlockCode As String, ByRef SelectedDirectory As String, _
                                        ByRef Product As String, ByRef CompanyName As String, ByRef NameComputer As String, _
                                        ByRef GeneratedFileNameLicenseFile As String) As Boolean

        'Dim Encryption1 As New Encryption()
        'Dim EncryptComputerName As String = Encryption1.StringEncrypt(compName, Encryption.keyForEncryptingStrings)
        'Dim path_root As String = StartupPath.Substring(0, StartupPath.LastIndexOf("\"))

        Dim LicenseFile As String = License.getLicenseFile(SelectedDirectory, Product, NameComputer)
        GeneratedFileNameLicenseFile = qs2.license.core.generic.getFileName(LicenseFile, True)

        System.GC.Collect()
        If System.IO.File.Exists(LicenseFile) Then
            System.IO.File.Delete(LicenseFile)
        End If
        System.GC.Collect()

        Dim Encryption1 As New Encryption()
        Dim EncryptProduct As String = Encryption1.StringEncrypt(Product.Trim(), Encryption.keyForEncryptingStrings)
        Dim EncryptCompany As String = Encryption1.StringEncrypt(CompanyName.Trim(), Encryption.keyForEncryptingStrings)
        Dim EncryptComputerName As String = Encryption1.StringEncrypt(NameComputer.Trim(), Encryption.keyForEncryptingStrings)

        Dim StreamWriter1 As New System.IO.StreamWriter(LicenseFile, False)
        StreamWriter1.WriteLine(EncryptProduct)
        StreamWriter1.WriteLine(EncryptCompany)
        StreamWriter1.WriteLine(EncryptComputerName)
        StreamWriter1.Close()
        System.GC.Collect()

        Return True

    End Function
    Public Shared Function getEncryptedUnlockCode(ByRef Product As String, ByRef CompanyName As String, ByRef NameComputer As String) As String
        Dim Encryption1 As New Encryption()

        Dim UnlockCode As String = Product.Trim() + "." + CompanyName.Trim() + "." + NameComputer.Trim()
        Dim EncryptUnlockCode As String = Encryption1.StringEncrypt(UnlockCode, Encryption.keyForEncryptingStrings)
        Return EncryptUnlockCode.Trim()
    End Function

    Public Shared Function getLicenseFile(ByRef SelectedDirectory As String, _
                                          ByRef Product As String, ByRef NameComputer As String) As String

        'Dim Encryption1 As New Encryption()
        'Dim EncryptComputerName As String = Encryption1.StringEncrypt(compName, Encryption.keyForEncryptingStrings)
        'Dim EncryptProduct As String = Encryption1.StringEncrypt(Product, Encryption.keyForEncryptingStrings)
        'Dim path_root As String = StartupPath.Substring(0, StartupPath.LastIndexOf("\"))

        Dim LicenseFileName As String = Product.Trim() + "." + NameComputer.Trim() + ""
        Dim LicenseFile As String = SelectedDirectory + "\" + LicenseFileName + ".licQS2"
        Return LicenseFile
    End Function

End Class
