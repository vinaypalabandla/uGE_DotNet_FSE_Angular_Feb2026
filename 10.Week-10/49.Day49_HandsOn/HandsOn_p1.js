"use strict";
//Generic function
function getFirstElement(items) {
    if (items.length === 0) {
        throw new Error("Array is empty");
    }
    return items[0];
}
//Generic Class
class DataManager {
    items = [];
    add(item) {
        this.items.push(item);
    }
    getAll() {
        return this.items;
    }
}
// Create DataManagers
const userManager = new DataManager();
const productManager = new DataManager();
// Add Users
userManager.add({ id: 1, name: "Vinay" });
userManager.add({ id: 2, name: "Ramu" });
// Add Products
productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Mobile" });
// Get All Data
const users = userManager.getAll();
const products = productManager.getAll();
// Display Data
console.log("Users:", users);
console.log("Products:", products);
// Use Generic Function
console.log("First User:", getFirstElement(users));
console.log("First Product:", getFirstElement(products));
