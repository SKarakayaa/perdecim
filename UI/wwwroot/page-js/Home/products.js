var url = window.location.origin;
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
      loadProducts();
    }
  );
});
loadProducts = () => {
  var row = "";
  products.forEach((product) => {
    row +=
      '<div class="col-md-4 product-tab-grid simpleCart_shelfItem"><div class="grid-arr"><div class="grid-arrival"><figure><a href="#" class="new-gri" data-toggle="modal" data-target="#myModal1"><div class="grid-img"><img src="' +
      url +
      '/images/p6.jpg" class="img-responsive" alt=""></div><div class="grid-img"><img src="' +
      url +
      '/images/p5.jpg" class="img-responsive" alt=""></div></a></figure></div><div class="block"><div class="starbox small ghosting"> </div></div><div class="women"><h6><a href="single.html">Sed ut perspiciatis unde</a></h6><span class="size">XL / XXL / S </span><p><del>$100.00</del><em class="item_price">$70.00</em></p><a href="#" data-text="Add To Cart" class="my-cart-b item_add">Add To Cart</a></div></div></div>';
  });
  $(".product-tab").html("").append(row);
};
