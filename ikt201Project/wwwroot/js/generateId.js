document.getElementById("generateRandomId").addEventListener("click", function () {
    // Generate a random ID (you may need to adjust this logic based on your requirements)
    var randomId = Math.floor(Math.random() * 900000) + 100000;

    // Set the generated random ID to the input field
    document.getElementById("ProductId").value = randomId;
});