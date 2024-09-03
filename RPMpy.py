def russian_peasant_multiplication(a, b):
    try:
        if a is None or b is None:
            raise ValueError("Both numbers must be provided.")
        
        if not (isinstance(a, int) and isinstance(b, int)):
            raise TypeError("Both numbers must be integers.")

        if a < 0 or b < 0:
            raise ValueError("Both numbers must be non-negative integers.")

        if a > 10**12 or b > 10**12:
            raise OverflowError("Inputs are too large to handle safely.")


        result = 0
        while a > 0:
            if a % 2 != 0: 
                result += b
            a //= 2
            b *= 2       
        
        return result

    except TypeError as te:
        print(f"Type error: {te}")
        return 0
    except ValueError as ve:
        print(f"Value error: {ve}")
        return 0
    except OverflowError as oe:
        print(f"Overflow error: {oe}")
        return 0
    except Exception as e:
        print(f"An unexpected error occurred: {e}")
        return 0


result = russian_peasant_multiplication(18, 25)
print(f"18 multiplied by 25 using Russian Peasant Multiplication is {result}")

error_result = russian_peasant_multiplication(-5, 10)
print(f"Result of multiplication with a value error: {error_result}")

type_error_result = russian_peasant_multiplication(18.5, 25)
print(f"Result of multiplication with a type error: {type_error_result}")

none_error_result = russian_peasant_multiplication(None, 10)
print(f"Result of multiplication with a None error: {none_error_result}")

overflow_error_result = russian_peasant_multiplication(10**13, 2)
print(f"Result of multiplication with an overflow error: {overflow_error_result}")
