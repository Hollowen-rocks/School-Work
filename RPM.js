function russianPeasantMultiplication(a, b) {
    try {
        if (typeof a !== 'number' || typeof b !== 'number') {
            throw new TypeError("Both numbers must be of type 'number'.");
        }
        if (a < 0 || b < 0 || !Number.isInteger(a) || !Number.isInteger(b)) {
            throw new RangeError("Both numbers must be non-negative integers.");
        }

        const MAX_SAFE_INTEGER = Number.MAX_SAFE_INTEGER;
        if (a > MAX_SAFE_INTEGER || b > MAX_SAFE_INTEGER) {
            throw new RangeError("Inputs are too large to handle safely.");
        }


        let result = 0;
        while (a > 0) {
            if (a % 2 !== 0) {
                result += b;
           
                if (result > MAX_SAFE_INTEGER) {
                    throw new RangeError("Addition resulted in overflow.");
                }
            }
            a = Math.floor(a / 2); 
            b *= 2;
            if (b > MAX_SAFE_INTEGER) {
                throw new RangeError("Multiplication resulted in overflow.");
            }
        }

        return result;

    } catch (error) {
        console.error(`Error: ${error.message}`);
        return 0;
    }
}

let result = russianPeasantMultiplication(18, 25);
console.log(`18 multiplied by 25 using Russian Peasant Multiplication is ${result}`);

let errorResult = russianPeasantMultiplication(-5, 10);
console.log(`Result of multiplication with a range error: ${errorResult}`);

let typeErrorResult = russianPeasantMultiplication(18.5, 25);
console.log(`Result of multiplication with a type error: ${typeErrorResult}`);

let overflowErrorResult = russianPeasantMultiplication(10e12, 2);
console.log(`Result of multiplication with an overflow error: ${overflowErrorResult}`);
