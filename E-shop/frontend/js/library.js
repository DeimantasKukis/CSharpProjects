function displayProducts(products, element) {
  let allItems = "";
  for (let index = 0; index < products.length; index++) {
    const product = products[index];

    let template =
      '<div class="col m4 s12"><div class="card"><div class="card-image waves-effect waves-block waves-light"> <img class="activator" src="{{photo}}"></div><div class="card-content"> <span class="card-title activator grey-text text-darken-4"> {{productName}} <br> Kaina: {{finalPrice}} € </br><i class="material-icons right" >more_vert</i > </span ><p> </p></div><div class="card-reveal"> <span class="card-title grey-text text-darken-4" >Pradinė Kaina: {{startPrice}} €<i class="material-icons right">close</i> </span ><p>  <br>Produkto aprašymas: {{productDescription}}</p></div></div></div>';

    template = template.replaceAll("{{photo}}", product.photo);
    template = template.replaceAll("{{productId}}", product.productId);
    template = template.replaceAll("{{productName}}", product.productName);
    template = template.replaceAll(
      "{{productDescription}}",
      product.productDescription
    );
    template = template.replaceAll("{{startPrice}}", product.startPrice);
    template = template.replaceAll("{{discount}}", product.discount);
    template = template.replaceAll("{{finalPrice}}", product.finalPrice);

    allItems += template;
  }

  element.innerHTML = allItems;
}

function showModal(element, event) {
  event.preventDefault();
  alert(element.getAttribute("href"));
}

function openNav() {
  document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
  document.getElementById("mySidenav").style.width = "0";
}
