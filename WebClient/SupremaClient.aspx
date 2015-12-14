<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="SupremaClient.aspx.cs" Inherits="WebService.SupremaClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BadgeMaker Server</title>
    <link href="themes/delta/theme.css" rel="stylesheet" type="text/css" />
    <link href="production/primeui-1.1-min.css" rel="stylesheet" type="text/css" />
    <link href="production/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="production/css/jquery-fullsizable.css" rel="stylesheet" type="text/css" />
    <link href="production/css/jquery-fullsizable-theme.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="production/js/jquery.min.js"></script>
    <script type="text/javascript" src="production/js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="production/primeui-1.1-min.js"></script>
    <script type="text/javascript" src="production/js/panel/panel.js"></script>
    <script type="text/javascript" src="production/js/fieldset/fieldset.js"></script>

    <script type="text/javascript" src="production/js/jquery.fullsizable.js"></script>
    <script type="text/javascript" src="production/js/jquery.touchSwipe.min.js"></script>

    <script type="text/javascript">
        function EnableImages() {
            $('.opticaImage').fullsizable({
                detach_id: 'container',
                navigation: true
            });
        }

        $(function () {
            $('.Panel').puipanel({
                toggleable: true
            });

            $('.ToggleFSet').puifieldset({
                toggleable: true
            });

            $('.NoToggleFSet').puifieldset({
                toggleable: false
            });

            $(document).on('fullsizable:opened', function () {
                $("#jquery-fullsizable").swipe({
                    swipeLeft: function () {
                        $(document).trigger('fullsizable:next')
                    },
                    swipeRight: function () {
                        $(document).trigger('fullsizable:prev')
                    },
                    swipeUp: function () {
                        $(document).trigger('fullsizable:close')
                    }
                });
            });

            EnableImages();
        });

    </script>
</head>
<body>
    <form id="frmMain" runat="server">
        <table>
            <tr>
                <td style="text-align: center;">
                    <div id="ConfigPanel" class="Panel" title="Suprema Web Service" style="width: 580px; max-height: 425px; border: none;">
                        <table>
                            <tr>
                                <td style="vertical-align: middle; text-align: center">
                                    <img id="fp01" runat="server" alt="" style="width: 100px; border: solid; border-width: 1px;" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <img id="fp02" runat="server" alt="" style="width: 100px; border: solid; border-width: 1px;" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <img id="fp03" runat="server" alt="" style="width: 100px; border: solid; border-width: 1px;" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <img id="fp04" runat="server" alt="" style="width: 100px; border: solid; border-width: 1px;" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <img id="fp05" runat="server" alt="" style="width: 100px; border: solid; border-width: 1px;" />
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; text-align: center">
                                    <asp:Button ID="btn_fp01" runat="server" Text="Capturar" OnClick="btnRun_Click" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <asp:Button ID="btn_fp02" runat="server" Text="Capturar" OnClick="btnRun_Click" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <asp:Button ID="btn_fp03" runat="server" Text="Capturar" OnClick="btnRun_Click" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <asp:Button ID="btn_fp04" runat="server" Text="Capturar" OnClick="btnRun_Click" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <asp:Button ID="btn_fp05" runat="server" Text="Capturar" OnClick="btnRun_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; text-align: center">
                                    <img id="fp06" runat="server" alt="" style="width: 100px; border: solid; border-width: 1px;" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <img id="fp07" runat="server" alt="" style="width: 100px; border: solid; border-width: 1px;" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <img id="fp08" runat="server" alt="" style="width: 100px; border: solid; border-width: 1px;" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <img id="fp09" runat="server" alt="" style="width: 100px; border: solid; border-width: 1px;" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <img id="fp10" runat="server" alt="" style="width: 100px; border: solid; border-width: 1px;" />
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; text-align: center">
                                    <asp:Button ID="btn_fp06" runat="server" Text="Capturar" OnClick="btnRun_Click" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <asp:Button ID="btn_fp07" runat="server" Text="Capturar" OnClick="btnRun_Click" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <asp:Button ID="btn_fp08" runat="server" Text="Capturar" OnClick="btnRun_Click" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <asp:Button ID="btn_fp09" runat="server" Text="Capturar" OnClick="btnRun_Click" />
                                </td>
                                <td style="vertical-align: middle; text-align: center">
                                    <asp:Button ID="btn_fp10" runat="server" Text="Capturar" OnClick="btnRun_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="MinPanel" class="Panel" title="Minucias Capturadas" style="border: none;">
                        <table>
                            <tr>
                                <td>1</td>
                                <td><asp:TextBox ID="txt01" runat="server" Width="240px"></asp:TextBox></td>
                                <td><asp:TextBox ID="minq01" runat="server" Width="40px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>2</td>
                                <td><asp:TextBox ID="txt02" runat="server" Width="240px"></asp:TextBox></td>
                                <td><asp:TextBox ID="minq02" runat="server" Width="40px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>3</td>
                                <td><asp:TextBox ID="txt03" runat="server" Width="240px"></asp:TextBox></td>
                                <td><asp:TextBox ID="minq03" runat="server" Width="40px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>4</td>
                                <td><asp:TextBox ID="txt04" runat="server" Width="240px"></asp:TextBox></td>
                                <td><asp:TextBox ID="minq04" runat="server" Width="40px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>5</td>
                                <td><asp:TextBox ID="txt05" runat="server" Width="240px"></asp:TextBox></td>
                                <td><asp:TextBox ID="minq05" runat="server" Width="40px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>6</td>
                                <td><asp:TextBox ID="txt06" runat="server" Width="240px"></asp:TextBox></td>
                                <td><asp:TextBox ID="minq06" runat="server" Width="40px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>7</td>
                                <td><asp:TextBox ID="txt07" runat="server" Width="240px"></asp:TextBox></td>
                                <td><asp:TextBox ID="minq07" runat="server" Width="40px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>8</td>
                                <td><asp:TextBox ID="txt08" runat="server" Width="240px"></asp:TextBox></td>
                                <td><asp:TextBox ID="minq08" runat="server" Width="40px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>9</td>
                                <td><asp:TextBox ID="txt09" runat="server" Width="240px"></asp:TextBox></td>
                                <td><asp:TextBox ID="minq09" runat="server" Width="40px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>10</td>
                                <td><asp:TextBox ID="txt10" runat="server" Width="240px"></asp:TextBox></td>
                                <td><asp:TextBox ID="minq10" runat="server" Width="40px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
