let choosedColorIds = [];
let choosedBrandIds = [];
FilterByColor = (colorId) => {
  const isChecked = $(`#color-check-${colorId}`).is(":checked");
  if (isChecked) {
    choosedColorIds.push(Number(colorId));
  } else {
    choosedColorIds = choosedColorIds.filter((x) => x !== Number(colorId));
  }
  FilterProduct();
};
FilterByBrand = (brandId) => {
  const isChecked = $(`#brand-check-${brandId}`).is(":checked");
  if (isChecked) {
    choosedBrandIds.push(Number(brandId));
  } else {
    choosedBrandIds = choosedBrandIds.filter((x) => x !== Number(brandId));
  }
  FilterProduct();
};
FilterProduct = () => {
  debugger;
  var filteredProducts = originalProductDatas;
  if (choosedColorIds.length === 0 && choosedBrandIds.length === 0) {
    products = originalProductDatas;
    loadProducts();
    return;
  }

  if (choosedColorIds.length !== 0) {
    var tempFilteredProducts = [];
    choosedColorIds.forEach((choosedColorId) => {
      var filteredProductsByColor = filteredProducts.filter((product) =>
        product.colorIds.includes(choosedColorId)
      );
      filteredProductsByColor.forEach((p) => {
        var isExist = tempFilteredProducts.some((x) => x.id === p.id);
        if (!isExist) tempFilteredProducts.push(p);
      });
    });
    filteredProducts = tempFilteredProducts;
  }

  if (choosedBrandIds.length !== 0) {
    filteredProducts = filteredProducts.filter((product) =>
      choosedBrandIds.includes(product.brandId)
    );
  }

  products = filteredProducts;
  loadProducts();
};
