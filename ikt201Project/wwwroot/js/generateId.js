document.getElementById("generateRandomId").addEventListener("click", function () {
    // Generate random id
    var randomId = Math.floor(Math.random() * 900000) + 100000;

    // Display the id generated
    document.getElementById("ProductId").value = randomId;
});