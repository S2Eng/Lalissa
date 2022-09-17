Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Globalization




Public Class cContextMenü

    Private _TXTControl1 As TXTextControl.TextControl
    Private _txSpellChecker As TXTextControl.Proofing.TXSpellChecker




    Public Sub TXTControlField_TextContextMenuOpening(sender As Object, e As TXTextControl.TextContextMenuEventArgs, _
                                                        ByRef contextMenuStripSpell As System.Windows.Forms.ContextMenuStrip, _
                                                        ByRef txSpellChecker1 As TXTextControl.Proofing.TXSpellChecker, _
                                                        ByRef doSpellChecking As Boolean, ByRef DesignMode As Boolean, _
                                                        ByRef TXTControl1 As TXTextControl.TextControl)
        Try
            Me._TXTControl1 = TXTControl1
            Me._txSpellChecker = txSpellChecker1

            If Not DesignMode Then
                If doSpellChecking Then
                    ' Set menu items if misspelled word was right clicked.
                    If (e.ContextMenuLocation And TXTextControl.ContextMenuLocation.MisspelledWord) = TXTextControl.ContextMenuLocation.MisspelledWord Then
                        ' Remove old items
                        contextMenuStripSpell.Items.Clear()

                        ' Look for a misspelled word at the current mouse position
                        Dim mousePosition As Point = TXTControl1.PointToClient(Cursor.Position)
                        Dim clientOffset As Point
                        ' Get the current activated IFormattedText and its offset value
                        Dim textPart As TXTextControl.IFormattedText = DirectCast(TXTControl1.TextParts.GetItem(clientOffset), TXTextControl.IFormattedText)
                        Dim pointToSearch As New Point(mousePosition.X - clientOffset.X, mousePosition.Y - clientOffset.Y)

                        ' Get the misspelled word
                        Dim misspelledWord As TXTextControl.MisspelledWord = textPart.MisspelledWords.GetItem(pointToSearch)

                        'Is there a misspelled word at the current mouse position?
                        If misspelledWord IsNot Nothing AndAlso Not misspelledWord.IsIgnored Then
                            ' Get an array of spell checking menu item (Delete-, NoSuggestion- or 5 Suggestion-, Ignore-, IgnoreAll- and AddToDictionary-Item)
                            Dim items As TXTextControl.Proofing.MenuItem() = txSpellChecker1.GetMenuItems(misspelledWord, TXTControl1, 5)
                            For Each item As TXTextControl.Proofing.MenuItem In items
                                'If the current misspelled word is a duplicated word, add the Delete- and the IgnoreOnce- item.
                                If misspelledWord.IsDuplicate AndAlso (item.Type = TXTextControl.Proofing.TXSpell.MenuItemType.Delete OrElse item.Type = TXTextControl.Proofing.TXSpell.MenuItemType.IgnoreOnce) Then
                                    contextMenuStripSpell.Items.Add(item)
                                Else
                                    ' If it is not a duplicated word then don't add it to the context menu strip.
                                    If item.Type <> TXTextControl.Proofing.TXSpell.MenuItemType.Delete Then
                                        ' Add a separator between the last Suggestion-item / the NoSuggestion-item
                                        ' and the ignore item
                                        If item.Type = TXTextControl.Proofing.TXSpell.MenuItemType.IgnoreOnce Then
                                            contextMenuStripSpell.Items.Add(New ToolStripSeparator())
                                        End If

                                        ' Only add the item, if it is not a duplicated word
                                        If Not misspelledWord.IsDuplicate Then
                                            contextMenuStripSpell.Items.Add(item)
                                        End If

                                        ' Disable the item, if the misspelled word is a NoSuggestion-item
                                        If item.Type = TXTextControl.Proofing.TXSpell.MenuItemType.NoSuggestions Then
                                            item.Enabled = False
                                        End If

                                        ' Enable the AddToDicitonary item, if the SpellChecker contains an editable
                                        ' user dictionary. Otherwise disable it.
                                        If item.Type = TXTextControl.Proofing.TXSpell.MenuItemType.AddToDictionary Then
                                            item.Enabled = txSpellChecker1.Dictionaries.HasEditableUserDictionaries
                                        End If
                                    End If
                                End If
                            Next
                            ' Add a separator between the spell checking menu items and the options item.
                            contextMenuStripSpell.Items.Add(New ToolStripSeparator())

                            ' Add an item to open the built-in spell check dialog
                            Dim dialogItem As New ToolStripMenuItem("Dialog Rechtschreibprüfung")      '("Spell Check Dialog...") 
                            AddHandler dialogItem.Click, AddressOf spellCheckDialog_Click
                            contextMenuStripSpell.Items.Add(dialogItem)

                            ' Add an item to open the built-in options dialog
                            dialogItem = New ToolStripMenuItem("Optionen")                              '("Options...")
                            AddHandler dialogItem.Click, AddressOf optionsDialog_Click
                            contextMenuStripSpell.Items.Add(dialogItem)

                            ' Replace default TextControl context menu with spell check context ment strip.
                            e.TextContextMenu = contextMenuStripSpell
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("cContextMenü.TXTControlField_TextContextMenuOpening: " + ex.ToString(), "Error")
        End Try
    End Sub

    Sub spellCheckDialog_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me._txSpellChecker.SpellCheckDialog.Show(Me._TXTControl1)
    End Sub

    ' Open the built-in options dialog when the "Options..." item was clicked
    Sub optionsDialog_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me._txSpellChecker.OptionsDialog()
    End Sub

End Class
