﻿Namespace AS3
    Public Class AS3Class
        Inherits AS3ClassInterfaceBase
        Public ImplementsNames As New List(Of String)

		Public Sub New(token As Token, as3SrcFile As AS3SrcFile)
			MyBase.New(token, as3SrcFile)
			Me.Access.IsInternal = True
		End Sub

		Public Overrides Sub Write(tabs As Integer, srcout As ISrcOut)

            srcout.WriteLn("package " & Package.Name, tabs)
            srcout.WriteLn("{", tabs)

            For Each s In Package.StamentsStack.Peek()
                s.Write(tabs + 1, srcout)
            Next


            WriteBody(tabs + 1, srcout)


            srcout.WriteLn("}", tabs)

            For Each c In innerClass
                c.WriteBody(tabs, srcout)
            Next
            For Each i In innerInterface
                i.WriteBody(tabs, srcout)
            Next

        End Sub

        Friend Sub WriteBody(tabs As Integer, srcout As ISrcOut)

            If Not IsOutPackage Then
                For Each im In Package.Import
                    srcout.WriteLn("import " & im.Name & ";", tabs)
                Next
            Else
                For Each im In Package.AS3File.OutPackageImports
                    srcout.WriteLn("import " & im.Name & ";", tabs)
                Next
            End If



            If Not Meta Is Nothing Then
                For Each m In Meta
                    m.Write(tabs, srcout)
                Next
                'Meta.Write(tabs, srcout)
            End If

            Dim cline As String = Access.ToString() & "class " & Name
            If ExtendsNames.Count > 0 Then
                cline &= " extends " & String.Join(",", ExtendsNames.ToArray())
            End If
            If ImplementsNames.Count > 0 Then
                cline &= " implements " & String.Join(",", ImplementsNames.ToArray())
            End If

            srcout.WriteLn(cline, tabs)
            srcout.WriteLn("{", tabs)

            For Each im In StamentsStack.Peek()
                im.Write(tabs + 1, srcout)
            Next

            srcout.WriteLn("}", tabs)
        End Sub

        
    End Class


End Namespace

