function getProducts() {
  return fetch(
    "http://deimantaskukis-001-site1.itempurl.com/api/Product/list"
    // "https://localhost:44316/api/Product/list"
  ).then((response) => response.json());
}

function createProduct(product) {
  return fetch(
    "http://deimantaskukis-001-site1.itempurl.com/api/Product/Create",
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json;charset=UTF-8",
      },
      body: JSON.stringify(product),
    }
  ).then((response) => {
    if (response.ok) {
      console.log(response);
    } else {
      alert("Yra bedu");
    }
  });
}
