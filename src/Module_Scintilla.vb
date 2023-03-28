Imports System.Globalization
Imports System.Text
Imports System.Text.Unicode
Imports System.Xml
Imports ScintillaNET
Imports VPKSoft.ScintillaLexers.CreateSpecificLexer
Imports VPKSoft.ScintillaLexers.HelperClasses
Imports VPKSoft.ScintillaLexers.LexerEnumerations

Partial Public Class Form1
    ' シンティラ表示初期化
    Private Sub ScintillaInitialize(fontFamily As String, Optional ByVal fontSize As Integer = 0, Optional ByVal selectedLang As String = "Default", Optional ByVal fontFamily2 As String = "Default", Optional ByVal fontSize2 As Integer = 10)
        For i As Integer = 1 To 6
            Dim inputBox As Scintilla
            Dim spacing As Integer
            If i = 6 Then
                inputBox = CType(chatForm.ChatBox, Scintilla)
                spacing = 5
                fontFamily = fontFamily2
                fontSize = fontSize2
            Else
                inputBox = CType(Controls.Find($"TextInput{i}", True)(0), Scintilla)
                spacing = 3
            End If
            inputBox.StyleResetDefault()
            If fontFamily = "Default" Then
                inputBox.Styles(Style.Default).Font = "Verdana"
                inputBox.Styles(Style.Default).Font = "MS Gothic"
                inputBox.Styles(Style.Default).Font = "Meiryo"
                inputBox.Styles(Style.Default).Font = "游ゴシック Regular"
                inputBox.Styles(Style.Default).Font = "BIZ UDゴシック"
            Else
                inputBox.Styles(Style.Default).Font = fontFamily
            End If
            If Not fontSize < 1 Then inputBox.Styles(Style.Default).Size = fontSize
            inputBox.Styles(Style.Default).BackColor = Color.FromArgb(42, 43, 55)
            inputBox.Styles(Style.Default).ForeColor = Color.White
            inputBox.ExtraAscent = spacing
            inputBox.ExtraDescent = spacing
            LexerFoldProperties.SetScintillaProperties(inputBox, LexerFoldProperties.DefaultFolding)
            inputBox.WrapMode = WrapMode.Char
            inputBox.StyleClearAll()
            'inputBox.Focus()
        Next

        For i As Integer = 2 To 4
            Dim inputBox As Scintilla
            If i = 3 Then
                inputBox = CType(chatForm.ChatBox, Scintilla)
            Else
                inputBox = CType(Controls.Find($"TextInput{i}", True)(0), Scintilla)
            End If

            inputBox.IndentationGuides = IndentView.LookBoth
            inputBox.Styles(Style.IndentGuide).ForeColor = Color.FromArgb(128, 128, 128)
            If i = 3 Then
                inputBox.Margins(0).Width = 45 ' マージン0の幅を設定
                inputBox.Margins(1).Width = 10 ' マージン1の幅を設定
            Else
                inputBox.Margins(0).Width = 30 ' マージン0の幅を設定
                inputBox.Margins(1).Width = 5 ' マージン1の幅を設定
            End If

            inputBox.Styles(Style.LineNumber).BackColor = Color.FromArgb(22, 23, 35) ' マージン0の背景色
            inputBox.Styles(Style.LineNumber).ForeColor = Color.FromArgb(100, 100, 100) ' マージン0の前景色
            inputBox.Margins(0).Type = MarginType.Number ' マージン0を行番号表示用に設定
            inputBox.Margins(1).Type = MarginType.RightText ' マージン0をライトテキスト表示用に設定
            inputBox.WhitespaceChars = "･"
            inputBox.SetWhitespaceForeColor(True, Color.FromArgb(90, 100, 128)) 'スペースのドット色を灰色に設定
            inputBox.WhitespaceSize = 2 'スペースのサイズを1に設定
            inputBox.ViewWhitespace = WhitespaceMode.VisibleAlways 'スペースを常に表示するように設定

            ' XMLファイルを読み込む
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
            Dim settings As XmlReaderSettings = New XmlReaderSettings()
            Dim context = New XmlParserContext(nt:=Nothing, nsMgr:=Nothing, xmlLang:=Nothing, XmlSpace.None)
            context.Encoding = Encoding.GetEncoding(1252)

            Using reader As XmlReader = XmlReader.Create(xmlFilePath, settings, context)
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(reader)

                ' 言語に合わせたLexerTypeタグを探す
                Dim lexerTypeNode As XmlNode = Nothing
                For Each node As XmlNode In xmlDoc.DocumentElement.SelectNodes("//LexerType")
                    Dim descAttr As XmlAttribute = node.Attributes("desc")
                    If descAttr IsNot Nothing AndAlso descAttr.Value = selectedLang Then
                        lexerTypeNode = node
                        Exit For
                    End If
                Next

                ' 言語に合わせたLexerTypeタグが見つからなければ処理を終了する
                If lexerTypeNode Is Nothing Then
                    'inputBox.Focus()
                    Continue For
                End If

                ' LexerTypeタグのnameキーを取得する
                Dim lexerTypeName As String = lexerTypeNode.Attributes("name").Value
                If lexerTypeName = "c" Then lexerTypeName = "cpp"
                If lexerTypeName = "cs" Then lexerTypeName = "cpp"
                If lexerTypeName = "javascript" Then lexerTypeName = "cpp"
                If lexerTypeName = "java" Then lexerTypeName = "cpp"
                If lexerTypeName = "rc" Then lexerTypeName = "cpp"
                If lexerTypeName = "asp" Then lexerTypeName = "cpp"
                If lexerTypeName = "objc" Then lexerTypeName = "cpp"
                If lexerTypeName = "nfo" Then lexerTypeName = "cpp"
                If lexerTypeName = "actionscript" Then lexerTypeName = "cpp"
                If lexerTypeName = "fortran77" Then lexerTypeName = "fortran"
                If lexerTypeName = "postscript" Then lexerTypeName = "cpp"
                If lexerTypeName = "autoit" Then lexerTypeName = "cpp"
                If lexerTypeName = "html" Then lexerTypeName = "hypertext"
                If lexerTypeName = "php" Then lexerTypeName = "phpscript"

                ' インデックスとなるstyleIDを取得して設定
                For Each wordStyleNode As XmlNode In lexerTypeNode.SelectNodes("WordsStyle")
                    Dim nameAttr As XmlAttribute = wordStyleNode.Attributes("name")
                    Dim styleIDAttr As XmlAttribute = wordStyleNode.Attributes("styleID")
                    Dim styleID As Integer
                    Dim styleFore As Integer
                    Dim styleBack As Integer
                    Dim styleBold As Boolean
                    If styleIDAttr IsNot Nothing Then
                        If styleBack >= 0 Then Integer.TryParse(styleIDAttr.Value, styleID)
                        Integer.TryParse(wordStyleNode.Attributes("fgColor").Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, styleFore)
                        Boolean.TryParse(wordStyleNode.Attributes("fontStyle").Value, styleBold)
                        If styleFore > 0 Then inputBox.Styles(styleID).ForeColor = Color.FromArgb(styleFore)
                        inputBox.Styles(styleID).Bold = styleBold
                    End If
                Next

                If Not lexerTypeName = "default" Then
                    ' スタイルを適用して、フォールディングプロパティを設定
                    inputBox.LexerName = lexerTypeName

                    If lexerTypeName = "batch" Then ScintillaKeyWords.SetKeywords(inputBox, LexerType.Batch)
                    If lexerTypeName = "cpp" Then ScintillaKeyWords.SetKeywords(inputBox, LexerType.Cpp)
                    If lexerTypeName = "cs" Then
                        ScintillaKeyWords.SetKeywords(inputBox, LexerType.Cs)
                        inputBox.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while")
                        inputBox.SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void")
                    End If
                    If lexerTypeName = "css" Then ScintillaKeyWords.SetKeywords(inputBox, LexerType.Css)
                    If lexerTypeName = "html" Then
                        ScintillaKeyWords.SetKeywords(inputBox, LexerType.HTML)
                        LexerFoldProperties.SetScintillaProperties(inputBox, LexerFoldProperties.HyperTextFolding)
                    End If
                    If lexerTypeName = "inno" Then ScintillaKeyWords.SetKeywords(inputBox, LexerType.InnoSetup)
                    If lexerTypeName = "javascript" Then
                        ScintillaKeyWords.SetKeywords(inputBox, LexerType.JavaScript)
                        inputBox.SetKeywords(0, "break case catch continue default delete do else false for function if in instanceof new null return super switch this throw true try typeof var while with" +
                "class debugger finally void enum export extends import implements interface let package private protected public static yield undefined const")
                    End If

                    If lexerTypeName = "java" Then ScintillaKeyWords.SetKeywords(inputBox, LexerType.Java)
                    If lexerTypeName = "json" Then ScintillaKeyWords.SetKeywords(inputBox, LexerType.Json)
                    If lexerTypeName = "nsis" Then ScintillaKeyWords.SetKeywords(inputBox, LexerType.Nsis)
                    If lexerTypeName = "pascal" Then ScintillaKeyWords.SetKeywords(inputBox, LexerType.Pascal)
                    If lexerTypeName = "phpscript" Then ScintillaKeyWords.SetKeywords(inputBox, LexerType.PHP)
                    If lexerTypeName = "powershell" Then ScintillaKeyWords.SetKeywords(inputBox, LexerType.WindowsPowerShell)
                    If lexerTypeName = "python" Then
                        ScintillaKeyWords.SetKeywords(inputBox, LexerType.Python)
                        inputBox.SetKeywords(0, "and as assert break class continue def del elif else except exec finally for from global if import in is lambda not or pass print raise return try while with yield""""cdef cimport cpdef")
                    End If
                    If lexerTypeName = "sql" Then
                        ScintillaKeyWords.SetKeywords(inputBox, LexerType.SQL)
                        LexerFoldProperties.SetScintillaProperties(inputBox, LexerFoldProperties.SqlFolding)
                    End If
                    If lexerTypeName = "vbscript" Then ScintillaKeyWords.SetKeywords(inputBox, LexerType.VbDotNet)
                    If lexerTypeName = "vb" Then
                        ScintillaKeyWords.SetKeywords(inputBox, LexerType.VbDotNet)
                        inputBox.SetKeywords(0, "debug release addhandler addressof aggregate alias and andalso ansi as assembly auto binary boolean byref byte byval call case catch cbool cbyte cchar cdate cdbl cdec char cint class clng cobj compare const continue csbyte cshort csng cstr ctype cuint culng cushort custom date decimal declare default delegate dim directcast distinct do double each else elseif end endif enum equals erase error event exit explicit false finally for friend from function get gettype getxmlnamespace global gosub goto group handles if implements imports in inherits integer interface into is isfalse isnot istrue join key let lib like long loop me mid mod module mustinherit mustoverride my mybase myclass namespace narrowing new next not nothing notinheritable notoverridable object of off on operator option optional or order orelse overloads overridable overrides paramarray partial preserve private property protected public raiseevent readonly redim rem removehandler resume return sbyte select set shadows shared short single skip static step stop strict string structure sub synclock take text then throw to true try trycast typeof uinteger ulong unicode until ushort using variant wend when where while widening with withevents writeonly xor")

                        inputBox.SetKeywords(1, "array backgroundworker bitmap button checkbox checkedlistbox colordialog combobox component contextmenustrip control datagridview dataset datetime datetimepicker dictionary directorysearcher errorprovider eventlog exception fileinfo filesystemwatcher flowlayoutpanel form graphics groupbox helpprovider hscrollbar iappdomainsetup iasyncresult ibindablecomponent ibuttoncontrol icloneable icollectdatta icollection icolumnmapping icolumnmappingcollection icommandexecutor icomparable icomparer icomponent icomponenteditorpagesite icontainercontrol iconvertible icurrencymanagerprovider icustomformatter idataadapter idatagridcolumnstyleeditingnotificationservice idatagrideditingservice idatagridvieweditingcell idatagridvieweditingcontrol idataobject idataparameter idataparametercollection idatareader idatarecord idbcommand idbconnection idbdataadapter idbdataparameter idbtransaction idevicecontext idictionary idictionaryenumerator idisposable idroptarget ienumerable ienumerator iequalitycomparer iequatable ifeaturesupport ifilereaderservice iformatprovider iformattable iformatter igroupping ihashcodeprovider ilist ilookup image imagelist imessagefilter inotifypropertychanged int16 int32 int64 iobservable iobserver iorderedenumerable iorderedqueryable iqueryable iqueryprovider iserializable iserviceprovider iset istructuralcomparable istructuralequatable itablemapping itablemappingcollection iwin32window iwindowtarget label linklabel list listbox listview maskedtextbox menustrip messagequeue monthcalendar nativewindow notifyicon numericupdown openfiledialog panel pen performancecounter picturebox point pointf printdialog printdocument process progressbar propertygrid radiobutton readonlycollection rectangle rectanglef regex richtextbox savefiledialog serialport servicecontroller size sizef solidbrush splitcontainer statusstrip system tabcontrol tablelayoutpanel textbox timer toolstrip toolstripcontainer tooltip trackbar type uint16 uint32 uint64 vscrollbar webbrowser")
                        inputBox.SetKeywords(2, "! # % @ &amp; i d f l r s ui ul us")

                    End If
                    If lexerTypeName = "xml" Then LexerFoldProperties.SetScintillaProperties(inputBox, LexerFoldProperties.XmlFolding)
                    If lexerTypeName = "yaml" Then ScintillaKeyWords.SetKeywords(inputBox, LexerType.YAML)
                End If
            End Using
        Next
        'inputForm.TextInput1.Focus()
    End Sub

    Private Sub FocusRun()
        chatForm.ChatBox.Focus()
        inputForm.TextInput5.Focus()
        inputForm.TextInput4.Focus()
        inputForm.TextInput3.Focus()
        inputForm.TextInput2.Focus()
        inputForm.TextInput1.Focus()
    End Sub

End Class