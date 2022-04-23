package io.unit.test.studies;

import io.unit.test.studies.FizzBuzz;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class FizzBuzzTests {
    private FizzBuzz fizzBuzz;

    @BeforeEach
    void setUp() {
        fizzBuzz = new FizzBuzz();
    }

    @Test
    void returnFizzWhenTheNumberIsDividesByThree() {

        assertEquals("Fizz", fizzBuzz.stringFor(3));
    }

    @Test
    void returnFizzWhenTheNumberIsDividesByFive() {

        assertEquals("Buzz", fizzBuzz.stringFor(5));
    }

    @Test
    void returnFizzBuzzWhenTheNumberIsDividedBothOfThreeAnFive(){
        assertEquals("FizzBuzz",fizzBuzz.stringFor(15));
    }

    @Test
    void returnTheNumberItselfWhenTheNumberIsNotDividedAnyOfThreeAndFive(){
        assertEquals("7",fizzBuzz.stringFor(7));
    }

    @Test
    void throwIllegalArgumentExceptionWhenTheNumberIsLessThanOneOrGreaterThanHundred() {
        assertThrows(IllegalArgumentException.class, () -> fizzBuzz.stringFor(-1));
        assertThrows(IllegalArgumentException.class, () -> fizzBuzz.stringFor(101));
    }
}