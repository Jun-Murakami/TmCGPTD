using System.Globalization;
using System.Text;
using System.Xml;
using ScintillaNET;
using VPKSoft.ScintillaLexers.CreateSpecificLexer;
using VPKSoft.ScintillaLexers.HelperClasses;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace TmCGPTD
{

    public partial class Form1
    {
        // シンティラ表示初期化
        public void ScintillaInitialize(string fontFamily, int fontSize = 0, string selectedLang = "Default", string fontFamily2 = "Default", int fontSize2 = 10)
        {
            float dpiScaleFactor = CreateGraphics().DpiX / 96.0f;
            for (int i = 1; i <= 6; i++)
            {
                Scintilla inputBox;
                int spacing;
                if (i == 6)
                {
                    inputBox = chatForm.ChatBox;
                    spacing = 6 * (int)dpiScaleFactor;
                    fontFamily = fontFamily2;
                    fontSize = fontSize2;
                }
                else
                {
                    inputBox = (Scintilla)Controls.Find($"TextInput{i}", true)[0];
                    spacing = 4 * (int)dpiScaleFactor;
                    inputBox.Margins.Left = 10 * (int)dpiScaleFactor;
                    inputBox.Margins.Right = 10 * (int)dpiScaleFactor;
                }
                inputBox.StyleResetDefault();
                if (fontFamily == "Default")
                {
                    inputBox.Styles[Style.Default].Font = "Verdana";
                    inputBox.Styles[Style.Default].Font = "MS Gothic";
                    inputBox.Styles[Style.Default].Font = "Meiryo";
                    inputBox.Styles[Style.Default].Font = "游ゴシック Regular";
                    inputBox.Styles[Style.Default].Font = "BIZ UDゴシック";
                }
                else
                {
                    inputBox.Styles[Style.Default].Font = fontFamily;
                }
                if (!(fontSize < 1))
                    inputBox.Styles[Style.Default].Size = fontSize;
                inputBox.Styles[Style.Default].BackColor = Color.FromArgb(42, 43, 55);
                inputBox.Styles[Style.Default].ForeColor = Color.White;
                inputBox.ExtraAscent = spacing;
                inputBox.ExtraDescent = spacing;
                LexerFoldProperties.SetScintillaProperties(inputBox, LexerFoldProperties.DefaultFolding);
                inputBox.WrapMode = WrapMode.Char;
                inputBox.StyleClearAll();
                // inputBox.Focus()
            }

            var styleID1 = default(int);
            var styleBack1 = default(int);
            for (int i = 2; i <= 4; i++)
            {
                Scintilla inputBox;
                if (i == 3)
                {
                    inputBox = chatForm.ChatBox;
                }
                else
                {
                    inputBox = (Scintilla)Controls.Find($"TextInput{i}", true)[0];
                }

                inputBox.IndentationGuides = IndentView.LookBoth;
                inputBox.Styles[Style.IndentGuide].ForeColor = Color.FromArgb(128, 128, 128);
                if (i == 3)
                {
                    inputBox.Margins[0].Width = 40 * (int)dpiScaleFactor; // マージン0の幅を設定
                    inputBox.Margins[1].Width = 5 * (int)dpiScaleFactor; // マージン1の幅を設定
                    inputBox.Margins.Left = 12 * (int)dpiScaleFactor;
                    inputBox.Margins.Right = 12 * (int)dpiScaleFactor;
                }
                else
                {
                    inputBox.Margins[0].Width = 20 * (int)dpiScaleFactor; // マージン0の幅を設定
                    inputBox.Margins[1].Width = 5 * (int)dpiScaleFactor;
                } // マージン1の幅を設定

                inputBox.Styles[Style.LineNumber].BackColor = Color.FromArgb(22, 23, 35); // マージン0の背景色
                inputBox.Styles[Style.LineNumber].ForeColor = Color.FromArgb(100, 100, 100); // マージン0の前景色
                inputBox.Margins[0].Type = MarginType.Number; // マージン0を行番号表示用に設定
                inputBox.Margins[1].Type = MarginType.RightText; // マージン0をライトテキスト表示用に設定
                inputBox.WhitespaceChars = "･";
                inputBox.SetWhitespaceForeColor(true, Color.FromArgb(90, 100, 128)); // スペースのドット色を灰色に設定
                inputBox.WhitespaceSize = 2; // スペースのサイズを1に設定
                inputBox.ViewWhitespace = WhitespaceMode.VisibleAlways; // スペースを常に表示するように設定

                // XMLファイルを読み込む
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var settings = new XmlReaderSettings();
                var context = new XmlParserContext(nt: null, nsMgr: null, xmlLang: null, XmlSpace.None);
                context.Encoding = Encoding.GetEncoding(1252);

                using (var reader = XmlReader.Create(xmlFilePath, settings, context))
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(reader);

                    // 言語に合わせたLexerTypeタグを探す
                    XmlNode lexerTypeNode = null;
                    foreach (XmlNode node in xmlDoc.DocumentElement.SelectNodes("//LexerType"))
                    {
                        var descAttr = node.Attributes["desc"];
                        if (descAttr is not null && (descAttr.Value ?? "") == (selectedLang ?? ""))
                        {
                            lexerTypeNode = node;
                            break;
                        }
                    }

                    // 言語に合わせたLexerTypeタグが見つからなければ処理を終了する
                    if (lexerTypeNode is null)
                    {
                        // inputBox.Focus()
                        continue;
                    }

                    // LexerTypeタグのnameキーを取得する
                    string lexerTypeName = lexerTypeNode.Attributes["name"].Value;
                    if (lexerTypeName == "c")
                        lexerTypeName = "cpp";
                    if (lexerTypeName == "cs")
                        lexerTypeName = "cpp";
                    if (lexerTypeName == "javascript")
                        lexerTypeName = "cpp";
                    if (lexerTypeName == "java")
                        lexerTypeName = "cpp";
                    if (lexerTypeName == "rc")
                        lexerTypeName = "cpp";
                    if (lexerTypeName == "asp")
                        lexerTypeName = "cpp";
                    if (lexerTypeName == "objc")
                        lexerTypeName = "cpp";
                    if (lexerTypeName == "nfo")
                        lexerTypeName = "cpp";
                    if (lexerTypeName == "actionscript")
                        lexerTypeName = "cpp";
                    if (lexerTypeName == "fortran77")
                        lexerTypeName = "fortran";
                    if (lexerTypeName == "postscript")
                        lexerTypeName = "cpp";
                    if (lexerTypeName == "autoit")
                        lexerTypeName = "cpp";
                    if (lexerTypeName == "html")
                        lexerTypeName = "hypertext";
                    if (lexerTypeName == "php")
                        lexerTypeName = "phpscript";

                    // インデックスとなるstyleIDを取得して設定
                    foreach (XmlNode wordStyleNode in lexerTypeNode.SelectNodes("WordsStyle"))
                    {
                        var nameAttr = wordStyleNode.Attributes["name"];
                        var styleIDAttr = wordStyleNode.Attributes["styleID"];
                        int styleFore;
                        bool styleBold;
                        if (styleIDAttr is not null)
                        {
                            if (styleBack1 >= 0)
                                int.TryParse(styleIDAttr.Value, out styleID1);
                            int.TryParse(wordStyleNode.Attributes["fgColor"].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out styleFore);
                            bool.TryParse(wordStyleNode.Attributes["fontStyle"].Value, out styleBold);
                            if (styleFore > 0)
                                inputBox.Styles[styleID1].ForeColor = Color.FromArgb(styleFore);
                            inputBox.Styles[styleID1].Bold = styleBold;
                        }
                    }

                    if (!(lexerTypeName == "default"))
                    {
                        // スタイルを適用して、フォールディングプロパティを設定
                        inputBox.LexerName = lexerTypeName;

                        if (lexerTypeName == "batch")
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.Batch);
                        if (lexerTypeName == "cpp")
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.Cpp);
                        if (lexerTypeName == "cs")
                        {
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.Cs);
                            inputBox.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
                            inputBox.SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void");
                        }
                        if (lexerTypeName == "css")
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.Css);
                        if (lexerTypeName == "html")
                        {
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.HTML);
                            LexerFoldProperties.SetScintillaProperties(inputBox, LexerFoldProperties.HyperTextFolding);
                        }
                        if (lexerTypeName == "inno")
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.InnoSetup);
                        if (lexerTypeName == "javascript")
                        {
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.JavaScript);
                            inputBox.SetKeywords(0, "break case catch continue default delete do else false for function if in instanceof new null return super switch this throw true try typeof var while with" + "class debugger finally void enum export extends import implements interface let package private protected public static yield undefined const");
                        }

                        if (lexerTypeName == "java")
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.Java);
                        if (lexerTypeName == "json")
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.Json);
                        if (lexerTypeName == "nsis")
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.Nsis);
                        if (lexerTypeName == "pascal")
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.Pascal);
                        if (lexerTypeName == "phpscript")
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.PHP);
                        if (lexerTypeName == "powershell")
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.WindowsPowerShell);
                        if (lexerTypeName == "python")
                        {
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.Python);
                            inputBox.SetKeywords(0, "and as assert break class continue def del elif else except exec finally for from global if import in is lambda not or pass print raise return try while with yield\"\"cdef cimport cpdef");
                        }
                        if (lexerTypeName == "sql")
                        {
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.SQL);
                            LexerFoldProperties.SetScintillaProperties(inputBox, LexerFoldProperties.SqlFolding);
                        }
                        if (lexerTypeName == "vbscript")
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.VbDotNet);
                        if (lexerTypeName == "vb")
                        {
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.VbDotNet);
                            inputBox.SetKeywords(0, "debug release addhandler addressof aggregate alias and andalso ansi as assembly auto binary boolean byref byte byval call case catch cbool cbyte cchar cdate cdbl cdec char cint class clng cobj compare const continue csbyte cshort csng cstr ctype cuint culng cushort custom date decimal declare default delegate dim directcast distinct do double each else elseif end endif enum equals erase error event exit explicit false finally for friend from function get gettype getxmlnamespace global gosub goto group handles if implements imports in inherits integer interface into is isfalse isnot istrue join key let lib like long loop me mid mod module mustinherit mustoverride my mybase myclass namespace narrowing new next not nothing notinheritable notoverridable object of off on operator option optional or order orelse overloads overridable overrides paramarray partial preserve private property protected public raiseevent readonly redim rem removehandler resume return sbyte select set shadows shared short single skip static step stop strict string structure sub synclock take text then throw to true try trycast typeof uinteger ulong unicode until ushort using variant wend when where while widening with withevents writeonly xor");

                            inputBox.SetKeywords(1, "array backgroundworker bitmap button checkbox checkedlistbox colordialog combobox component contextmenustrip control datagridview dataset datetime datetimepicker dictionary directorysearcher errorprovider eventlog exception fileinfo filesystemwatcher flowlayoutpanel form graphics groupbox helpprovider hscrollbar iappdomainsetup iasyncresult ibindablecomponent ibuttoncontrol icloneable icollectdatta icollection icolumnmapping icolumnmappingcollection icommandexecutor icomparable icomparer icomponent icomponenteditorpagesite icontainercontrol iconvertible icurrencymanagerprovider icustomformatter idataadapter idatagridcolumnstyleeditingnotificationservice idatagrideditingservice idatagridvieweditingcell idatagridvieweditingcontrol idataobject idataparameter idataparametercollection idatareader idatarecord idbcommand idbconnection idbdataadapter idbdataparameter idbtransaction idevicecontext idictionary idictionaryenumerator idisposable idroptarget ienumerable ienumerator iequalitycomparer iequatable ifeaturesupport ifilereaderservice iformatprovider iformattable iformatter igroupping ihashcodeprovider ilist ilookup image imagelist imessagefilter inotifypropertychanged int16 int32 int64 iobservable iobserver iorderedenumerable iorderedqueryable iqueryable iqueryprovider iserializable iserviceprovider iset istructuralcomparable istructuralequatable itablemapping itablemappingcollection iwin32window iwindowtarget label linklabel list listbox listview maskedtextbox menustrip messagequeue monthcalendar nativewindow notifyicon numericupdown openfiledialog panel pen performancecounter picturebox point pointf printdialog printdocument process progressbar propertygrid radiobutton readonlycollection rectangle rectanglef regex richtextbox savefiledialog serialport servicecontroller size sizef solidbrush splitcontainer statusstrip system tabcontrol tablelayoutpanel textbox timer toolstrip toolstripcontainer tooltip trackbar type uint16 uint32 uint64 vscrollbar webbrowser");
                            inputBox.SetKeywords(2, "! # % @ &amp; i d f l r s ui ul us");

                        }
                        if (lexerTypeName == "xml")
                            LexerFoldProperties.SetScintillaProperties(inputBox, LexerFoldProperties.XmlFolding);
                        if (lexerTypeName == "yaml")
                            ScintillaKeyWords.SetKeywords(inputBox, LexerType.YAML);
                    }
                }
            }
            // inputForm.TextInput1.Focus()
        }

        private void FocusRun()
        {
            chatForm.ChatBox.Focus();
            inputForm.TextInput5.Focus();
            inputForm.TextInput4.Focus();
            inputForm.TextInput3.Focus();
            inputForm.TextInput2.Focus();
            inputForm.TextInput1.Focus();
        }

    }
}