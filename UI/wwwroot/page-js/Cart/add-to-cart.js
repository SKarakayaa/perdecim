var choosedDemands = [];

$(".value-plus1").on("click", function () {
  var divUpd = $(this).parent().find(".value1"),
    newVal = parseInt(divUpd.text(), 10) + 1;
  divUpd.text(newVal);
});

$(".value-minus1").on("click", function () {
  var divUpd = $(this).parent().find(".value1"),
    newVal = parseInt(divUpd.text(), 10) - 1;
  if (newVal >= 1) divUpd.text(newVal);
});

demandChange = (e) => {
  if (!choosedDemands.some((x) => x.Id === e.id))
    choosedDemands.push({ Id: e.id, Value: e.value });
};

$(".item_add2").click(() => {
  const demandCount = parseInt($("#demandCount").val());
  if (demandCount !== choosedDemands.length) $("#demandError").show();
  else {
    $("#demandError").hide();
    var productId = $("#productId").val();
    var quantity = parseInt($(".value1").text(), 10);
    var note = $("#note").val();
    const model = {
      ProductId: productId,
      DemandTypes: choosedDemands,
      Quantity: quantity,
      Note: note
    };
    $.post("/Cart/AddToCart", { model: model }, (response) => {
      $("#not-empty-cart").removeClass("hidden");
      $("#empty-cart").addClass("hidden");

      $(".simpleCart_quantity2").text(response.cartCount);
      $(".simpleCart_total2").text(`${response.totalPrice} ₺`);

      Swal.fire("Sepete Eklendi !", "Ürününüz Sepete Eklenmiştir !", "success");
    });
  }
});
