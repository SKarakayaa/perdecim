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
      row += `<div class="col-md-4 product-tab-grid simpleCart_shelfItem"><div class="grid-arr"><div class="grid-arrival"><figure><a href="#" class="new-gri" data-toggle="modal" data-target="#myModal1"><div class="grid-img"><img src="${url}/images/p6.jpg" class="img-responsive" alt=""></div><div class="grid-img"><img src="${url}/images/p5.jpg" class="img-responsive" alt=""></div></a></figure></div><div class="block"><div class="starbox small ghosting"> </div></div><div class="women"><h6><a href="/Product/Index/${product.id}">${product.name}</a></h6><span class="size">${product.description}</span>`;
      if (product.discountRate !== 0) {
        var discountedPrice =
          product.price - product.price * (product.discountRate / 100);
        row += `<p><del>${product.price} ₺</del><em class="item_price">${discountedPrice} ₺</em></p>`;
      } else {
        row += `<p><em class="item_price">${product.price} ₺</em></p>`;
      }
      row += `<a href="#" data-text="Add To Cart" class="my-cart-b item_add">Sepete Ekle</a></div></div></div>`;
    });
  }
  $(".product-tab").html("").append(row);
};
