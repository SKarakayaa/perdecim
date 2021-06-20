var url = window.location.origin;
var originalProductDatas = [];
var products = [];

$(document).ready(function () {
  var categoryId = $("#categoryId").val();

  $("#slider").slider({
    range: true,
    min: 0,
    max: 9000,
    values: [1000, 7000],
    slide: function (event, ui) {
      $("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
    },
  });
  $("#amount").val(
    "$" +
      $("#slider").slider("values", 0) +
      " - $" +
      $("#slider").slider("values", 1)
  );

  $.post(
    "/Home/GetProductList",
    { categoryId: categoryId },
    function (response) {
      response.forEach((product) => {
        var colorIds = [];
        product.productColors.forEach(pColor => colorIds.push(pColor.colorId));
        product.colorIds = colorIds;
        products.push(product);
      });
      originalProductDatas = products;
      loadProducts();
    }
  );
});
loadProducts = () => {
  var row = "";
  if (products.length === 0) {
    row += "<h2>Ürün Bulunamadı !</h2>";
  } else {
    products.forEach((product) => {
      row += '<div class="col-md-4 product-tab-grid simpleCart_shelfItem">';
      row += '<div class="grid-arr" style="height: 430px;">';
      row += '<div class="grid-arrival">';
      row += "<figure>";
      row +=
        '<a href="#" class="new-gri" data-toggle="modal" data-target="#myModal1">';
      product.productImages.forEach((image) => {
        row += `<div class='grid-img'><img src='/images/${image.imageName}' class='img-responsive' alt='${image.imageName}'/></div>`;
      });
      row += `</a></figure></div><div class="block"><div class="starbox small ghosting"> </div></div><div class="women"><h6><a href="/Product/Index/${
        product.id
      }">${product.name}</a></h6><span class="size">${
        product.description.length <= 25
          ? product.description
          : product.description.substring(0, 25) + "..."
      }</span>`;
      if (product.discountRate !== 0) {
        var discountedPrice =
          product.price - product.price * (product.discountRate / 100);
        row += `<p><del>${
          product.price
        } ₺</del><em class="item_price">${discountedPrice.toFixed(
          2
        )} ₺</em></p>`;
      } else {
        row += `<p><em class="item_price">${product.price} ₺</em></p>`;
      }
      row += `<a href="#" data-text="Add To Cart" class="my-cart-b item_add">Sepete Ekle</a></div></div></div>`;
    });
  }
  $(".product-tab").html("").append(row);
};
