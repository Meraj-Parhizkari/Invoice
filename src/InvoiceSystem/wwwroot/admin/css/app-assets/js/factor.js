/*const { cleanData } = require("jquery");*/
// انجام محاسبات فاکتور
function Computing() {
    //Calculate the number and price
    var number = parseInt(document.getElementById("number").value);
    var price = parseInt(document.getElementById("price").value);
    var total = number * price;
    parseInt(document.getElementById("total").value = total)
    //Calculate discount
    var discount = parseInt(document.getElementById("discount").value);
    var total_with_discount = total - discount;
    parseInt(document.getElementById("total_with_discount").value = total_with_discount);
    //Calculate Taxation
    var Taxation = (total_with_discount * 9) / 100;
    parseInt(document.getElementById("Taxation").value = Taxation);
    var Total_Tax = total_with_discount + Taxation;
    parseInt(document.getElementById("Total_Tax").value = Total_Tax);

}
// گرفتن کالا ها توسط گروه کالای آن
function LoadProductsByProductCategoryId(id,sid) {
    //$("#ProductName").val("");
    $.ajax({
        url: "/Admin/Products/GetProductByProductCategoryId",
        type: 'POST',
        data: { "id": id },
        dataType: "JSON",
        success: function (result) {
            $("#ProductId").empty();
            if (result.length > 0) {
                $("#ProductId").append($("<option>", {
                    //value: "",
                    text: 'لطفا انتخاب کنید...'
                }));
                $.each(result, function (index, item) {
                    //console.log(index);
                    //console.log(item.productName);
                    $("#ProductId").append($("<option>", {
                        value: item.id,
                        text: item.productName
                    }));

                });
                if (sid>=0) {
                    $("#ProductId").val(sid);
                    console.log(sid);
                }
            } else {
                $("#ProductId").append($("<option>", {
                    value: "",
                    text: 'هیچ داده ای یافت نشد!'
                }));

            }
        }
    });

}
//  در صورت تعویض گروه کالا در مودال کالا 
$(".ProductCategorySelectId").change(function () {

    LoadProductsByProductCategoryId($(this).val());

})
// در صورت تعویض گروه کالا در صفحه سفارش  
$("#ProductCategoryId").change(function () {

    LoadProductsByProductCategoryId($(this).val());
    // انتخاب دسته بندی در مودال
    $(".ProductCategorySelectId").val($(this).val());

})
//  در صورت تعویض گروه کالا در مودال کالا 
$(".ProductCategorySelectId").change(function () {
    $("#ProductCategoryId").val($(this).val());
})

// تایید ایجاد کالای جدید در مودال آن
CreateProductSuccess = function (result) {
    if (result.success) {
        $("#ProductCode").val("");
        $("#UserId").val("");
        $(".empty").val("");
        LoadProductsByProductCategoryId($(".ProductCategorySelectId").val(), result.entity.id);
        alert("محصول با موفقیت ایجاد گردید!");


    }
}
// گرفتن نام کالا از ایدی کالا 
$("#ProductId").change(function () {
    $(".ProductNameDisplay").val("");
    $(".ProductNameDisplay").val($("#ProductId option:selected").text());
});
// تایید ایجاد گروه کالا در مودال آن
ProductCategorySuccess = function (result) {
    if (result.success) {
        alert("گروه محصول با موفقیت ایجاد گردید!");
        //=======================
        $.ajax({
            url: "/Admin/Productcategories/ShowProductCategoryList",
            datatype: "JSON",
            type: 'Get',
            success: function (result) {
                $("#ParentId").empty();
                $(".ProductCategoryItems").empty();
                $("#Name").val("");
                if (result.length > 0) {
                    $("#ParentId").append($("<option>", {
                        value: "",
                        text: 'در صورت نیاز انتخاب کنید...'
                    }));
                    $.each(result, function (index, item) {
                        //console.log(index);
                        //console.log(item.productName);
                        $("#ParentId").append($("<option>", {
                            value: item.id,
                            text: item.name
                        }));
                    });
                    $(".ProductCategoryItems").append($("<option>", {
                        value: "",
                        text: 'در صورت نیاز انتخاب کنید...'
                    }));
                    $.each(result, function (index, item) {
                        $(".ProductCategoryItems").append($("<option>", {
                            value: item.id,
                            text: item.name
                        }));
                    });
                } else {
                    $(".ProductCategoryItems").append($("<option>", {
                        value: "",
                        text: 'هیچ داده ای یافت نشد!'
                    }));
                }
            }
        });
    }
}


// تایید ایجاد مشتری جدید در مودال آن
CreatePeopleSuccess = function () {
    alert("مشتری با موفقیت ایجاد گردید!");
    $.ajax({
        url: "/Admin/People/GetPeopleList",
        dataType: "JSON",
        type: "Get",
        success: function (result) {
            $("#BuyerId").empty();
            $(".Name").val("");
            $("#EconomicalNumber").val("");
            $("#RegisterNumber").val("");
            $("#NationalCode").val("");
            $("#TownId").val("");
            $("#Phone").val("");
            $("#ZipCode").val("");
            $("#Fax").val("");
            $("#Address").val("");
            $("#Email").val("");
            

            $.each(result, function (index, item) {
                $("#BuyerId").append($("<option>", {
                    value: item.id,
                    text: item.name
                }));
            });

        }
    })

}

function RemoveItemFromShoppingCard(id) {

    $.ajax({
        url: "/admin/Orders/RemoveRemoveItemFromShoppingCard",
        type: 'POST',
        data: { "id": id },
        dataType: "JSON",
        success: function (result) {
        }, error: function (error) {
        },
        complete: function (result) {
            $("#ShoppingList").load("ShowShoppingList");
        }
    });
}

// لود کردن لیست کالا ها
function completed() {
    //$("#ShoppingList").html(d);
    $("#ShoppingList").load("ShowShoppingList");
}

$("#province").change(function myfunction() {
    $.ajax({
        url: "/Admin/CountryDivisions/GetCountryDivisionsByParentId",
        type: 'POST',
        data: { "id": $(this).val() },
        dataType: "JSON",
        success: function (result) {
            $("#TownId").empty();
            if (result.length > 0) {
                $("#TownId").append($("<option>", {
                    text: 'شهر را انتخاب کنید'
                }));
                $.each(result, function (index, item) {
                    $("#TownId").append($("<option>", {
                        value: item.id,
                        text: item.name
                    }));
                });
            } else {
                $("#TownId").append($("<option>", {
                    value: "",
                    text: 'هیچ داده ای یافت نشد!'
                }));
            }
        }
    })
});