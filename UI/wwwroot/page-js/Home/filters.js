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
  var filteredProducts = originalProductDatas;
  if (choosedColorIds.length === 0 && choosedBrandIds.length === 0) {
    products = originalProductDatas;
    loadProducts();
    return;
  }

  if (choosedColorIds.length !== 0)
    filteredProducts = filteredProducts.filter((product) =>
      choosedColorIds.includes(product.colorId)
    );

  if (choosedBrandIds.length !== 0)
    filteredProducts = filteredProducts.filter((product) =>
      choosedBrandIds.includes(product.brandId)
    );

  products = filteredProducts;
  loadProducts();
};
