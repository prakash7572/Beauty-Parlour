//...............Start price.................//

    function loadData() {
        $.ajax({
            url: "/beauty/price",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += `<td>${key + 1}</td>`;
                    html += `<td>${item.subTitle}</td>`;
                    html += `<td>${item.makeup}</td>`;
                    html += `<td>${item.description}</td>`;
                    html += `<td>${item.prices}</td>`;
                    html += `<td>
                                 <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetPrice(${item.id})"><i class="fa fa-edit"></i></a>
                                 <a href="#" onclick="DelPrice(${item.id})"><i class="fa fa-trash"></i></a>
                                 </td>`;
                    html += '</tr>';
                });
                $('#pricelist').html(html);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    loadData();
    function Clear() {
        $('form#priceForm').trigger("reset");
        $("#ID").val(0);
    }
    function GetPrice(id) {
        $.ajax({
            url: `/beauty/price?id=${id}`,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $("#Price").val(result[0].prices);
                $("#SubTitle").val(result[0].subTitle);
                $("#Makeup").val(result[0].makeup);
                $("#Description").val(result[0].description);
                $("#ID").val(result[0].id);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
     function submitPrice() {
        var price = {
            ID: $('#ID').val(),
            SubTitle: $('#SubTitle').val(),
            Makeup: $('#Makeup').val(),
            Prices: $('#Price').val(),
            Description: $('#Description').val()
        };
        $.ajax({
            url: "/beauty/price",
            data: JSON.stringify(price),
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                alert(result.message);
                window.location.href = '/beauty/beautyprice';
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
        return false;
    }
    function DelPrice(id) {
        if (!confirm("Are you sure you want to delete this Record?")) {
            return false;
        } else {
            $.ajax({
                url: `/beauty/deleteprice?id=${id}`,
                type: "GET",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    alert(result.message);
                    loadData();
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        };
    }
//...............End price.................//
