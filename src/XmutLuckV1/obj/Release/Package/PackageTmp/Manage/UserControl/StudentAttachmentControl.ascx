<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentAttachmentControl.ascx.cs"
    Inherits="XmutLuckV1.Manage.UserControl.StudentAttachmentControl" %>
<%@ Register Src="~/Manage/UserControl/UploadLabelControl.ascx" TagName="UploadLabelControl"
    TagPrefix="uc" %>
<div class="attachment">
    <asp:PlaceHolder ID="phAction" runat="server">
        <div class="action">
            <uc:UploadLabelControl ID="UploadLabelControl" runat="server">
            </uc:UploadLabelControl>
        </div>
    </asp:PlaceHolder>
    <div class="list">
        <telerik:RadGrid ID="radAttachment" runat="server" AutoGenerateColumns="false" OnDeleteCommand="radGrid_DeleteCommand"
            AllowCustomPaging="false" AllowPaging="false" OnItemDataBound="radAttachment_ItemDataBound">
            <MasterTableView DataKeyNames="ID" AllowCustomPaging="False" AllowPaging="False">
                <Columns>
                    <telerik:GridBoundColumn DataField="Index" HeaderText="序号">
                        <HeaderStyle Width="60px" HorizontalAlign="Left" />
                        <ItemStyle Width="60px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FileLabel" HeaderText="描述">
                        <HeaderStyle Width="300px" HorizontalAlign="Left" />
                        <ItemStyle Width="300px" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <div class="image-item">
                                <asp:LinkButton ID="link2Attachment" runat="server">
                                    <span>
                                        <asp:Image ID="imgAttachement" runat="server" ImageUrl='<%#Eval("ImagePath") %>' />
                                    </span>
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="delete" Text="删除" OnClientClick="if(!DeleteAttachmentItem())return false;"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</div>
<script type="text/javascript">
    function DeleteAttachmentItem() {
        if (typeof BeforeDeleteAttachmentItem == "function") {
            return BeforeDeleteAttachmentItem();
        }
        return true;
    }
</script>