//Generic function uisng
function getFirstElement<T>(items: T[]): T {
    if (items.length === 0) {
        throw new Error("Array is empty");
    }
    return items[0];
}

//Generic interface using
interface Repository<T> {
    add(item: T): void;
    getAll(): T[];
}

//Generic Class using
class DataManager<T> implements Repository<T> {
    private items: T[] = [];

    add(item: T): void {
        this.items.push(item);
    }

    getAll(): T[] {
        return this.items;
    }
}

//Models  Use Case Implementation
interface User {
    id: number;
    name: string;
}

interface Product {
    id: number;
    title: string;
}

// Create DataManagers
const userManager = new DataManager<User>();
const productManager = new DataManager<Product>();

// Add Users Data
userManager.add({ id: 1, name: "Vinay" });
userManager.add({ id: 2, name: "Ramu" });

// Add Products Data
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