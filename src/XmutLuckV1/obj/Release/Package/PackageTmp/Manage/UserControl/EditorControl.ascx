<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditorControl.ascx.cs" Inherits="XmutLuckV1.Manage.UserControl.EditorControl" %>
<telerik:RadEditor ID="radEditor1" runat="server" Height="600px" Width="800px" CssClass="editor-description" ImageManager-UploadPaths="~/Image/" >
    <Modules>
        <telerik:EditorModule Visible="false" />
    </Modules>
    <Tools>
        <telerik:EditorToolGroup>
            <telerik:EditorTool Name="SelectAll" ShortCut="CTRL+A" />
            <telerik:EditorSeparator />
            <telerik:EditorTool Name="Bold" ShortCut="CTRL+B" />
            <telerik:EditorTool Name="Italic" ShortCut="CTRL+I" />
            <telerik:EditorTool Name="Underline" ShortCut="CTRL+U" />
            <telerik:EditorTool Name="StrikeThrough" />
            <telerik:EditorSeparator />
            <telerik:EditorTool Name="InsertOrderedList" />
            <telerik:EditorTool Name="InsertUnorderedList" />
            <telerik:EditorTool Name="InsertParagraph" />
            <telerik:EditorTool Name="InsertSymbol" />
            <telerik:EditorSeparator />
            <telerik:EditorTool Name="JustifyLeft" />
            <telerik:EditorTool Name="JustifyCenter" />
            <telerik:EditorTool Name="JustifyRight" />
        </telerik:EditorToolGroup>
        <telerik:EditorToolGroup Tag="MainToolbar">
            <telerik:EditorTool Name="Cut" />
            <telerik:EditorTool Name="Copy" ShortCut="CTRL+C" />
            <telerik:EditorTool Name="Paste" ShortCut="CTRL+V" />
            <telerik:EditorTool Name="PasteStrip" />
            <telerik:EditorSeparator />
            <telerik:EditorTool Name="Undo" ShortCut="CTRL+Z" />
            <telerik:EditorTool Name="Redo" ShortCut="CTRL+Y" />
            <telerik:EditorSeparator />
            <telerik:EditorTool Name="FormatStripper" />
            <telerik:EditorTool Name="ToggleScreenMode" ShortCut="F11" />
            <telerik:EditorTool Name="Print" ShortCut="CTRL+P" />
            <telerik:EditorTool Name="ImageManager" ShortCut="File" />
        </telerik:EditorToolGroup>
    </Tools>
</telerik:RadEditor>