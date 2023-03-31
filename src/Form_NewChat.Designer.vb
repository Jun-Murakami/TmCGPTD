Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms

Namespace TmCGPTD
    <CompilerServices.DesignerGenerated()>

    ' フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    Public Partial Class Form_NewChat
        Inherits Form

                ''' Cannot convert MethodDeclarationSyntax, System.ArgumentOutOfRangeException: 種類 'System.ArgumentOutOfRangeException' の例外がスローされました。
''' パラメーター名:node
''' 実際の値は not null です。
'''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.ConvertToVariableDeclaratorOrNull(IsPatternExpressionSyntax node)
'''    場所 System.Linq.Enumerable.WhereSelectListIterator`2.MoveNext()
'''    場所 System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
'''    場所 System.Linq.Enumerable.<ConcatIterator>d__59`1.MoveNext()
'''    場所 System.Linq.Buffer`1..ctor(IEnumerable`1 source)
'''    場所 System.Linq.Enumerable.ToArray[TSource](IEnumerable`1 source)
'''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.ConvertToDeclarationStatement(List`1 des, List`1 isPatternExpressions)
'''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.InsertRequiredDeclarations(SyntaxList`1 convertedStatements, CSharpSyntaxNode originaNode)
'''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.ConvertStatement(StatementSyntax statement, CSharpSyntaxVisitor`1 methodBodyVisitor)
'''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.<>c__DisplayClass10_0.<ConvertStatements>b__0(StatementSyntax s)
'''    場所 System.Linq.Enumerable.<SelectManyIterator>d__17`2.MoveNext()
'''    場所 Microsoft.CodeAnalysis.SyntaxList`1.CreateNode(IEnumerable`1 nodes)
'''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.ConvertStatements(SyntaxList`1 statements, MethodBodyExecutableStatementVisitor iteratorState)
'''    場所 ICSharpCode.CodeConverter.VB.CommonConversions.ConvertBody(BlockSyntax body, ArrowExpressionClauseSyntax expressionBody, Boolean hasReturnType, MethodBodyExecutableStatementVisitor iteratorState)
'''    場所 ICSharpCode.CodeConverter.VB.NodesVisitor.VisitMethodDeclaration(MethodDeclarationSyntax node)
'''    場所 Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    場所 ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
''' 
'''         // フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
'''         [System.Diagnostics.@DebuggerNonUserCodeAttribute()]
'''         protected override void Dispose(bool disposing)
'''         {
'''             try
'''             {
'''                 if (disposing && this.components is not null)
'''                 {
'''                     this.components.Dispose();
'''                 }
'''             }
'''             finally
'''             {
'''                 base.Dispose(disposing);
'''             }
'''         }
''' 
''' 

        ' Windows フォーム デザイナーで必要です。
        Private components As System.ComponentModel.IContainer

        ' メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
        ' Windows フォーム デザイナーを使用して変更できます。  
        ' コード エディターを使って変更しないでください。
        <DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Label23 = New Label()
            TextBox1 = New TextBox()
            AddHandler TextBox1.KeyDown, New KeyEventHandler(AddressOf TextBox1_KeyDown)
            ButtonCancel = New Button()
            AddHandler ButtonCancel.Click, New EventHandler(AddressOf ButtonCancel_Click)
            ButtonOK = New Button()
            AddHandler ButtonOK.Click, New EventHandler(AddressOf ButtonOK_Click)
            SuspendLayout()
            ' 
            ' Label23
            ' 
            Label23.AutoSize = True
            Label23.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
            Label23.Location = New Point(19, 19)
            Label23.Margin = New Padding(10)
            Label23.Name = "Label23"
            Label23.Size = New Size(149, 19)
            Label23.TabIndex = 56
            Label23.Text = "Please enter the title."
            ' 
            ' TextBox1
            ' 
            TextBox1.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
            TextBox1.Location = New Point(19, 68)
            TextBox1.Name = "TextBox1"
            TextBox1.Size = New Size(300, 29)
            TextBox1.TabIndex = 57
            ' 
            ' ButtonCancel
            ' 
            ButtonCancel.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
            ButtonCancel.Location = New Point(175, 130)
            ButtonCancel.Margin = New Padding(0, 15, 15, 15)
            ButtonCancel.Name = "ButtonCancel"
            ButtonCancel.Size = New Size(120, 40)
            ButtonCancel.TabIndex = 59
            ButtonCancel.Text = "Cancel"
            ButtonCancel.UseVisualStyleBackColor = True
            ' 
            ' ButtonOK
            ' 
            ButtonOK.Font = New Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point)
            ButtonOK.Location = New Point(43, 130)
            ButtonOK.Margin = New Padding(15)
            ButtonOK.Name = "ButtonOK"
            ButtonOK.Size = New Size(120, 40)
            ButtonOK.TabIndex = 58
            ButtonOK.Text = "OK"
            ButtonOK.UseVisualStyleBackColor = True
            ' 
            ' Form_NewChat
            ' 
            AutoScaleDimensions = New SizeF(7F, 15F)
            AutoScaleMode = AutoScaleMode.Font
            ClientSize = New Size(337, 196)
            Controls.Add(ButtonCancel)
            Controls.Add(ButtonOK)
            Controls.Add(TextBox1)
            Controls.Add(Label23)
            FormBorderStyle = FormBorderStyle.FixedToolWindow
            Name = "Form_NewChat"
            StartPosition = FormStartPosition.CenterParent
            Text = "New Chat"
            AddHandler Shown, New EventHandler(AddressOf Form_NewChat_Shown)
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Friend Label23 As Label
        Friend TextBox1 As TextBox
        Friend ButtonCancel As Button
        Friend ButtonOK As Button
    End Class
End Namespace
