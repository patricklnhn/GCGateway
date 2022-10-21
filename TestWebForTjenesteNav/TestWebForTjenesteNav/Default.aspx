<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script src=https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.1.js type="text/javascript"></script>
        <script src=https://ajax.aspnetcdn.com/ajax/jquery.ui/1.12.1/jquery-ui.js type="text/javascript"></script>
        <link href=https://ajax.aspnetcdn.com/ajax/jquery.ui/1.12.1/themes/blitzer/jquery-ui.css rel="Stylesheet" type="text/css" /> 

    <script type="text/javascript">
        $(function () {
            $("[id$=sokadresse]").autocomplete({
                source: function (request, response) {
                    $.ajax(
                        {
                            url: '/Default.aspx/GetAdresser',
                            data: "{'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return { label: item }

                                }))
                            }

                        }
                    );
                },
                messages: { noResults: 'Ingen treff', results: function () { } },
                error: function (xhr, ajaxoptions, thrownError) { alert(xhr.status); alert(thrownError); },
                select: function (e, i) {
                    $("[id$=parsedaddr]").val(i.item.value.split('-  ')[0]);
                    $("[id$=parsedaddr]").text(i.item.value.split('-  ')[0]);
                    $("[id$=sokpostnr]").val(i.item.value.split(' -  ')[1].split(' ')[0]);
                    $("[id$=sokpoststed]").val(i.item.value.split('-  ')[1].split(' ')[1]);
                    txt = document.getElementById("txtResultat");
                    txt.value = 'Now calling GetCoverageForGCAddressAsync from Javascript part 2';
                    $.ajax({
                        url: '/Default.aspx/GetCoverageForGCAddressAsync',
                        data: "{'searchstring': ' '}",
                        dataType: "json",
                        type: "GET",
                        contentType: "application/json; charset=utf-8",
                        success: async function (data) {
                            txt.value = await $.data;
                        }
                    },)

                    //Call New API at GC for gabid
                    //$.ajax(
                    //    {
                    //        url: '/Default.aspx/GetCoverageForGCAddressAsync',
                    //        data: "{'searchstring': '" + document.getElementById("parsedaddr").value + " " + document.getElementById("sokpostnr").value + " " + document.getElementById("sokpoststed").value + "'}",
                    //        dataType: "json",
                    //        type: "POST",
                    //        contentType: "application/json; charset=utf-8",
                    //        success: async function(data) {
  
                    //            txt.value = await $.data;
                    //            //return data;
                    //            //for (var i = 0; i < data.d.results.length; i++) {
                    //            //    var item = data.d.results[i];
                    //            //    //console.log(item.Title);
                    //            //} 
                    //        },
                    //        error: function (xhr, ajaxoptions, thrownError) { alert('Error xhr ' + $(xhr.status)); alert('Thrown error ' + $(thrownError)); }

                    //    }
                    //);

                },
                minLength: 4
            });
        });
    </script>

<script type="text/javascript">
    $(function () {
        $("[id$=JuntaNamesearch]").autocomplete({
            source: function (request, response) {
                $.ajax(
                    {
                        url: '/Default.aspx/GetJuntaName',
                        data: "{'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { label: item }

                            }))
                        }

                    }
                );
            },
            messages: { noResults: 'Ingen treff', results: function () { } },
            error: function (xhr, ajaxoptions, thrownError) { alert(xhr.status); alert(thrownError); },
            select: function (e, i) {
                $("[id$=parsedaddr]").val(i.item.value.split('-  ')[0]);
                $("[id$=parsedaddr]").text(i.item.value.split('-  ')[0]);
                $("[id$=sokpostnr]").val(i.item.value.split(' -  ')[1].split(' ')[0]);
                $("[id$=sokpoststed]").val(i.item.value.split('-  ')[1].split(' ')[1]);
                txt = document.getElementById("txtResultat");
                txt.value = 'Now calling GetCoverageForGCAddressAsync from Javascript part 2';
                $.ajax({
                    url: '/Default.aspx/GetCoverageForGCAddressAsync',
                    data: "{'searchstring': ' '}",
                    dataType: "json",
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    success: async function (data) {
                        txt.value = await $.data;
                    }
                })

            }, minlength: 4
        })
    })
</script>
         <!--   
            //messages: { noResults: 'Ingen treff', results: function () { } },
            //error: function (xhr, ajaxoptions, thrownError) { alert(xhr.status); alert(thrownError); },
                //select: function (e, i) {
                //    $("[id$=parsedaddr]").val(i.item.value.split('-  ')[0]);
                //    $("[id$=parsedaddr]").text(i.item.value.split('-  ')[0]);
                //    $("[id$=sokpostnr]").val(i.item.value.split(' -  ')[1].split(' ')[0]);
                //    $("[id$=sokpoststed]").val(i.item.value.split('-  ')[1].split(' ')[1]);
                //    txt = document.getElementById("txtResultat");
                //    txt.value = 'Now calling GetCoverageForGCAddressAsync from Javascript part 2';
                //    $.ajax({
                //        url: '/Default.aspx/GetCoverageForGCAddressAsync',
                //        data: "{'searchstring': ' '}",
                //        dataType: "json",
                //        type: "GET",
                //        contentType: "application/json; charset=utf-8",
                //        success: async function (data) {
                //            txt.value = await $.data;
                //        }
                //    },
//)
//    },
//        minlength: 3
//});
             -->

<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="sokadresse" runat="server" OnTextChanged="sokadresse_TextChanged" Width="501px" placeholder="Gateadresse"></asp:TextBox>
            <br />
            <asp:TextBox runat="server" ID="parsedaddr"></asp:TextBox>
            <br />
            <asp:TextBox runat="server" ID="sokpostnr"></asp:TextBox>
            <br />
            <asp:TextBox runat="server" ID="sokpoststed"></asp:TextBox>
            <br />
            <asp:TextBox runat="server" ID="txtResultat"></asp:TextBox>
            <br />
            
            <hr />
            <asp:TextBox runat="server" ID="JuntaNamesearch" OnTextChanged="JuntaNamesearch_TextChanged"></asp:TextBox>

            <hr />
            <br />
            <br />
            <br />

            <asp:Label runat="server" id="lblOrgnummer"></asp:Label>Orgnummer: <asp:TextBox runat="server" id="txtOrgnummer"/>
            <br />
            <asp:Label runat="server" id="lblContactid">ContactId: </asp:Label><asp:TextBox runat="server" id="txtContactId"/>
            <br />
            <asp:Button runat="server" ID="butPost" Text ="Send" OnClick="butPost_Click" />
        </div>
    </form>
</body>
</html>

