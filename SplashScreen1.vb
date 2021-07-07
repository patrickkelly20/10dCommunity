Public NotInheritable Class SplashScreen1

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).
        Dim strPath As String = Zen_DTD_File
        Dim strRoot As String = Zen_DTD_File.Replace("zen.dtd", "")
        Dim strName As String = "zen"
        Dim strEXT As String = ".dtd"
        Dim intCounter As Integer = 0
        Dim dir1 As String = AppData + "\Tenac10us"
        If System.IO.Directory.Exists(dir1) Then
        Else
            System.IO.Directory.CreateDirectory(dir1)
        End If
        Dim dir2 As String = AppData + "\Tenac10us\10d"
        If System.IO.Directory.Exists(dir2) Then
        Else
            System.IO.Directory.CreateDirectory(dir2)
        End If
        Dim dir3 As String = AppData + "\Tenac10us\10d\input"
        If System.IO.Directory.Exists(dir3) Then
        Else
            System.IO.Directory.CreateDirectory(dir3)
        End If
        Dim dir4 As String = AppData + "\Tenac10us\10d\kys"
        If System.IO.Directory.Exists(dir4) Then
        Else
            System.IO.Directory.CreateDirectory(dir4)
        End If
        Dim dir5 As String = AppData + "\Tenac10us\10d\kys"
        If System.IO.Directory.Exists(dir5) Then
        Else
            System.IO.Directory.CreateDirectory(dir5)
        End If
        'If System.IO.File.Exists(AppContext.BaseDirectory + "miked16k_pri.xml") And Not System.IO.File.Exists(dir5 + "\miked16k_pri.xml") Then
        '    System.IO.File.Copy(AppContext.BaseDirectory + "miked16k_pri.xml", dir5 + "\miked16k_pri.xml")
        '    If System.IO.File.Exists(AppContext.BaseDirectory + "miked16k_pub.xml") And Not System.IO.File.Exists(dir5 + "\miked16k_pub.xml") Then
        '        System.IO.File.Copy(AppContext.BaseDirectory + "miked16k_pub.xml", dir5 + "\miked16k_pub.xml")
        '    End If
        'End If
        Dim dir6 As String = AppData + "\Tenac10us\10d\output"



            If System.IO.Directory.Exists(dir6) Then
        Else
            System.IO.Directory.CreateDirectory(dir6)
        End If
        Dim dir7 As String = AppData + "\Tenac10us\10d\process"
        If System.IO.Directory.Exists(dir7) Then
        Else
            System.IO.Directory.CreateDirectory(dir7)
        End If
        Dim dir8 As String = AppData + "\Tenac10us\10d\working"
        If System.IO.Directory.Exists(dir8) Then
        Else
            System.IO.Directory.CreateDirectory(dir8)
        End If
        Dim dir9 As String = AppData + "\Tenac10us\10d\zen"
        If System.IO.Directory.Exists(dir9) Then
        Else
            System.IO.Directory.CreateDirectory(dir9)
        End If
        Dim file1 As String = AppData + "\Tenac10us\10d\kys\10d_pri.xml"
        If System.IO.File.Exists(file1) Then
        Else
            Dim sw As System.IO.StreamWriter = System.IO.File.CreateText(file1)
            sw.WriteLine("<RSAKeyValue>")

            sw.WriteLine("<Modulus>1HXFebvvrTDCLf/xUkvZPb9ewtqahE8J5eM75Tfc3p04wZfZ87ssOo25ZxOvvdk5H2zr+/IIVnjzsrsj9kKSozjEqULOlbP060CVSZXIGR6qHo1JWvP+bh/1fFZmLfh/O+qzAsyVKyDeEoLJ848UOarzIsca6KPgTGRK8LtS7JSgl3RZX6dyPLL/MlnBINTJH8zSQ6pM4aynX1PM4M4KlS8Jw15VZRr/2Ww2kig2byZvKHqfVPcP9+kMjqgZGKmYtW28CdVRlZl7mvWNulVX8JgQ342WT4FE5T0+CbV8HfahQRAfauvxiMA0KpvCKz8GCA6V872k2ThPXOu0Nm3MfazlxGC2LATAeJo75RaFNCZSWWI4Mer+AwZ19SpMhmOLg0BrtfQ/ys89EpxmmBm8NTQn7r8KF8Ieq263ASF4MapxWAZF0VnN8w3EZPSC8iNAbCmJxb9wNv9Js24up4TNlybTD2uyqeCaHo3l3oPGJv+UAj/Ot/D87s484rA6L/ax</Modulus>")

            sw.WriteLine("<Exponent>AQAB</Exponent>")

            sw.WriteLine("<P>/yLlN1i7yS+ApaoQC0WSKNHuOpCK1lJ0Van0F4NTAD93PIGfSymgf8TFMMe6PvKxmlfczmnfmmqJm4P2xdJAgiUd0FL1+hBjqW7CcUYy6e+OUSKeA6tukhXH3PIFsptUEoBm03SYfV1Jg/F+8hSK6ciXGwVGYTzq2yRD1rs4MqKe6vXgA1dOkZX8kZ7ywmv/vhsW0tR9tLVeT7gNIh9mTnOAecthMnjQzbyZpA1EHzzvdsDtEOgpIBvBCD8i5Lm5</P>")

            sw.WriteLine("<Q>1S3kZagIPJ1720mizlGSVtA9J4BgTxw9Clg1nQ1W6wv2akiHaK5OgsEUstuJKVFXUqeNoGAXKLxt2kGc9xM6W2uYE8XtM9uwn/unZgaF60os8FhrJ/LTDyefY1NGJoqbZmA/5psYvg/PzQsrJcph5o3psCy+gvMucqd9NWfVujXNmDh4aWDZmiPP2sl/L6ZnLy11ydv4Ds7IcLheS+9yyESsAx6DmX5bnVFJ+1ok9v2IWVWn+/ZYT2GBSuwV88C5</Q>")

            sw.WriteLine("<DP>LWV7HX73YtPF8zQwSKEnYYYA+oCvg3UGaBumZ+yg/yFLyQNTYZ9VhIZxg712AS9TtJ+/lSa3d5VPSNGRPh+sBLwv8tpgFA+IfCROCrOv6XoLe5pKPWLqeKnRdxnFM8N5kRUxtpw/accIhqaYrOBE21YqtM8ad8DMFRP90h5b4H6ZAjufkViejT7/wrVign+O8LeHNxpCB75hupOIGrM1k+3vRTyP3dgrZwAQ4mTN4zUHcrzfMavtbV4i2aHKRqJZ</DP>")

            sw.WriteLine("<DQ>ZL1NI2Tmj450S0pe71TI7NF3NMWLvZbAmbTZkSAOpQCAL/WaV7OXUl7f4y2vgaD4vQyE9vaxuwRgfTVocbHab/1GXoG3+DunGdMYZjRK8MeauPFvoe80IgM9ZPijO+9gRF7Tk6xTYu2h62mNuEwNO6BwgFqEpOk6V+AiYSxyaY6nW3nEHTgxXI/z15ZEzkW6mSbIdN3IOWcqfWoC1auP+GfLSaYP1mdJ7+vMJEWTFkz1NBIwUfc2AD05lig+r3Ox</DQ>")

            sw.WriteLine("<InverseQ>qWiCUk3DQptgI9NYnX274A4ZmIkovXFsA3nwmtn48DT77/d/DgUfiP5cu2r7N9aLceKb961UUIONBlT3omPQzdi+e+PjoY/9tpEN7/czatfgps+3a2vSX7PN19jvURWS0qmxJ+xx58GuAY/wSL+FEmQh6HpuxzLQHhXdTehFa3JbXDBYNhEh00bMcLtk6FI89HmsFYHJnth6pQf+L1whRMVH0IrprA2e+KfAOAcgnaoKXmzYeg9fzKonCpyj6NWf</InverseQ>")

            sw.WriteLine("<D>a7+yv/M9MXN590RHSfpnmXY1g9LD7Hf9SBZ/KNe07z2DLENr6L0zSBraPVlxlnHVE4f1AliUO+6pgSqBqYHHxnmi20ijZq7WdnzReXk5+utfUZFL85GspoMUx9M1jPjq5iM4WCITQMUxeufTre8RTdHR7wBVOEjsFzICA6as/oi+DTGXpfhQ6lHJNOrqFFF2EueYd3Kl/QnH9IOWcyhrm484f1mXK2iO+uBzqJo2SRaP51KQ/dEyywLpOGwuFiDkARTiKal+hcArcbAhJjuv8Qj0MzkHwZWcNURqImhDJilHSWVVJtxCD3sGj9m0yAPsW03NP2cqEc0H7JWcgKZO50mESlWCvxUaNfAlspJ2UGnikt/PLH28SEdkav984V9OhMBfMXSPjE40Xh05xzqMNdZnzpLVYXsbt4pO/MoOcQqmIp/DqHaGkdmW9/lpIcRp2XwXSDxtbiWz6tIhsUGOF5iGZ+Tm2DVrSk6QVRt4Y2njy9i2g3kjIsWZ3TGSJaFB</D>")

            sw.Write("</RSAKeyValue>")
            sw.Flush()
            sw.Close()
            sw.Dispose()
        End If

        Dim file2 As String = AppData + "\Tenac10us\10d\kys\10d_pub.xml"

        If Not System.IO.File.Exists(file2) Then

            Dim sw As System.IO.StreamWriter = System.IO.File.CreateText(file2)

            sw.WriteLine("<RSAKeyValue>")

            sw.WriteLine("<Modulus>1HXFebvvrTDCLf/xUkvZPb9ewtqahE8J5eM75Tfc3p04wZfZ87ssOo25ZxOvvdk5H2zr+/IIVnjzsrsj9kKSozjEqULOlbP060CVSZXIGR6qHo1JWvP+bh/1fFZmLfh/O+qzAsyVKyDeEoLJ848UOarzIsca6KPgTGRK8LtS7JSgl3RZX6dyPLL/MlnBINTJH8zSQ6pM4aynX1PM4M4KlS8Jw15VZRr/2Ww2kig2byZvKHqfVPcP9+kMjqgZGKmYtW28CdVRlZl7mvWNulVX8JgQ342WT4FE5T0+CbV8HfahQRAfauvxiMA0KpvCKz8GCA6V872k2ThPXOu0Nm3MfazlxGC2LATAeJo75RaFNCZSWWI4Mer+AwZ19SpMhmOLg0BrtfQ/ys89EpxmmBm8NTQn7r8KF8Ieq263ASF4MapxWAZF0VnN8w3EZPSC8iNAbCmJxb9wNv9Js24up4TNlybTD2uyqeCaHo3l3oPGJv+UAj/Ot/D87s484rA6L/ax</Modulus>")

            sw.WriteLine("<Exponent>AQAB</Exponent>")

            sw.Write("</RSAKeyValue>")

            sw.Flush()
            sw.Close()
            sw.Dispose()
        End If


        If Not System.IO.File.Exists(strPath) Then
            Dim sw As System.IO.StreamWriter = System.IO.File.CreateText(strPath)
            sw.WriteLine("<?xml encoding=""utf-8""?>")
            sw.WriteLine("<!--  -->")
            sw.WriteLine("<!ELEMENT zen (history,mail)>")
            sw.WriteLine("<!-- XMLNS attribute -->")
            sw.WriteLine("<!ATTLIST zen xmlns:xsi CDATA #REQUIRED date CDATA #IMPLIED xmlns:noNamespaceSchemaLocation CDATA #REQUIRED>")
            sw.WriteLine("<!-- Contents elements -->")
            sw.WriteLine("<!ELEMENT history (file*)>")
            sw.WriteLine("<!ELEMENT file (fileName,host,password,d1,ts)>")
            sw.WriteLine("<!ATTLIST file  id ID #REQUIRED>")
            sw.WriteLine("<!ELEMENT fileName (#PCDATA)>")
            sw.WriteLine("<!ELEMENT host (#PCDATA)>")
            sw.WriteLine("<!ELEMENT password (#PCDATA)>")
            sw.WriteLine("<!ELEMENT d1 (#PCDATA)>")
            sw.WriteLine("<!ELEMENT ts (#PCDATA)>")
            sw.WriteLine("<!ELEMENT mail (message*)>")
            sw.WriteLine("<!ELEMENT message (stamp,FileName,Password,ssl,smtp,port,user,smtppassword,d,TS,from,to,cc,bcc,subject,Message,html)>")
            sw.WriteLine("<!ATTLIST message  id ID #REQUIRED>")
            sw.WriteLine("<!ELEMENT stamp (#PCDATA)>")
            sw.WriteLine("<!ELEMENT FileName (#PCDATA)>")
            sw.WriteLine("<!ELEMENT Password (#PCDATA)>")
            sw.WriteLine("<!ELEMENT ssl (#PCDATA)>")
            sw.WriteLine("<!ELEMENT smtp (#PCDATA)>")
            sw.WriteLine("<!ELEMENT port (#PCDATA)>")
            sw.WriteLine("<!ELEMENT user (#PCDATA)>")
            sw.WriteLine("<!ELEMENT smtppassword (#PCDATA)>")
            sw.WriteLine("<!ELEMENT d (#PCDATA)>")
            sw.WriteLine("<!ELEMENT TS (#PCDATA)>")
            sw.WriteLine("<!ELEMENT from (#PCDATA)>")
            sw.WriteLine("<!ELEMENT to (#PCDATA)>")
            sw.WriteLine("<!ELEMENT cc (#PCDATA)>")
            sw.WriteLine("<!ELEMENT bcc (#PCDATA)>")
            sw.WriteLine("<!ELEMENT subject (#PCDATA)>")
            sw.WriteLine("<!ELEMENT Message (#PCDATA)>")
            sw.WriteLine("<!ELEMENT html (#PCDATA)>")
            sw.Flush()
            sw.Close()
            sw.Dispose()
        End If
        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).
        Dim strZenPath As String = Zen_xsd_File
        Dim strZenRoot As String = Zen_xsd_File.Replace("zen.xsd", "")
        Dim strZenName As String = "zen"
        Dim strZenEXT As String = ".xsd"
        'Dim intCounter As Integer = 0
        If Not System.IO.File.Exists(strZenPath) Then
            Dim sw As System.IO.StreamWriter = System.IO.File.CreateText(strZenPath)
            sw.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            sw.WriteLine("<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"">")
            sw.WriteLine("<xs:element name=""zen"">")
            sw.WriteLine("<xs:complexType>")
            sw.WriteLine("<xs:sequence>")
            sw.WriteLine("<xs:element name=""history"">")
            sw.WriteLine("<xs:complexType>")
            sw.WriteLine("<xs:sequence>")
            sw.WriteLine("<xs:element name=""file"" minOccurs=""0"" maxOccurs=""unbounded"">")
            sw.WriteLine("<xs:complexType>")
            sw.WriteLine("<xs:sequence>")
            sw.WriteLine("<xs:element name=""fileName"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""host"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""password"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""d1"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""ts"" type=""xs:string""/>")
            sw.WriteLine("</xs:sequence>")
            sw.WriteLine("<xs:attribute name=""id"" type=""xs:string""/>")
            sw.WriteLine("</xs:complexType>")
            sw.WriteLine("</xs:element>")
            sw.WriteLine("</xs:sequence>")
            sw.WriteLine("</xs:complexType>")
            sw.WriteLine("</xs:element>")
            sw.WriteLine("<xs:element name=""mail"">")
            sw.WriteLine("<xs:complexType>")
            sw.WriteLine("<xs:sequence>")
            sw.WriteLine("<xs:element name=""message"" minOccurs=""0"" maxOccurs=""unbounded"">")
            sw.WriteLine("<xs:complexType>")
            sw.WriteLine("<xs:sequence>")
            sw.WriteLine("<xs:element name=""stamp"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""FileName"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""Password"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""ssl"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""smtp"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""port"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""user"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""smtppassword"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""d"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""TS"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""from"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""to"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""cc"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""bcc"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""subject"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""Message"" type=""xs:string""/>")
            sw.WriteLine("<xs:element name=""html"" type=""xs:string""/>")
            sw.WriteLine("</xs:sequence>")
            sw.WriteLine("<xs:attribute name=""id"" type=""xs:string""/>")
            sw.WriteLine("</xs:complexType>")
            sw.WriteLine("</xs:element>")
            sw.WriteLine("</xs:sequence>")
            sw.WriteLine("</xs:complexType>")
            sw.WriteLine("</xs:element>")
            sw.WriteLine("</xs:sequence>")
            sw.WriteLine("</xs:complexType>")
            sw.WriteLine("</xs:element>")
            sw.WriteLine("</xs:schema>")
            sw.Flush()
            sw.Close()
            sw.Dispose()
        End If

        'Application title
        If My.Application.Info.Title <> "" Then
            'ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            'ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright
    End Sub

    Private Sub MainLayoutPanel_Paint(sender As Object, e As PaintEventArgs) Handles MainLayoutPanel.Paint

    End Sub
End Class
