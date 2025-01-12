// Example cart data (this would typically come from a backend, localStorage, etc.)
let cartData = [
    { id: 1, name: 'Pet Toy', price: 19.99, quantity: 1 },
    { id: 2, name: 'Dog Food', price: 29.99, quantity: 1 },
    { id: 3, name: 'Cat Bed', price: 49.99, quantity: 1 }
];

// Function to update the cart display and total
function updateCartDisplay() {
    const cartItemsContainer = document.getElementById('cart-items');
    const totalPriceElement = document.getElementById('total-price');
    let totalPrice = 0;

    cartItemsContainer.innerHTML = ''; // Clear existing items

    // Check if cart is empty
    if (cartData.length === 0) {
        cartItemsContainer.innerHTML = '<p>Your cart is empty.</p>';
        totalPriceElement.textContent = '$0.00';
        return;
    }

    // Loop through each item in the cart and display it
    cartData.forEach(item => {
        const cartItem = document.createElement('div');
        cartItem.classList.add('cart-item');
        cartItem.innerHTML = `
            <p>${item.name} - $${item.price.toFixed(2)} x ${item.quantity}</p>
            <button onclick="removeItem(${item.id})">Remove</button>
            <button onclick="addItem(${item.id})">Add One More</button>
            <button onclick="decreaseItem(${item.id})">Remove One</button>
        `;
        cartItemsContainer.appendChild(cartItem);
        totalPrice += item.price * item.quantity; // Accumulate total price
    });

    // Update total price
    totalPriceElement.textContent = `$${totalPrice.toFixed(2)}`;
}

// Function to add one more item to the cart (increase quantity)
function addItem(itemId) {
    const item = cartData.find(item => item.id === itemId);
    if (item) {
        item.quantity += 1;  // Increase quantity by 1
        updateCartDisplay();  // Re-render the cart
    }
}

// Function to remove one item from the cart (decrease quantity)
function decreaseItem(itemId) {
    const item = cartData.find(item => item.id === itemId);
    if (item && item.quantity > 1) {
        item.quantity -= 1;  // Decrease quantity by 1
        updateCartDisplay();  // Re-render the cart
    }
}

// Function to remove an item from the cart completely
function removeItem(itemId) {
    cartData = cartData.filter(item => item.id !== itemId);  // Remove item by ID
    updateCartDisplay();  // Re-render the cart
}

// Function to proceed to checkout
function proceedToCheckout() {
    if (cartData.length === 0) {
        alert("Your cart is empty! Add items before proceeding.");
        return; // If cart is empty, do not proceed to checkout
    }
    
    // Optionally, show a message confirming the checkout process
    alert("Proceeding to checkout...");
    
    // Redirect to checkout page after alert
    window.location.href = 'checkout.html';  // Ensure 'checkout.html' exists in the same directory
}

// Initial cart display call (will render the cart on page load)
updateCartDisplay();
