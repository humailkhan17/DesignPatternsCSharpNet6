using DesignPatternsCSharpNet6.Memento;

namespace Test.DesignPatternsCSharpNet6.MementoPattern;

public class TestMementoPattern
{
    private const string ORIGINAL_ADDRESS = "1234 Main Street";
    private const string CHANGED_ADDRESS_1 = "4321 Elm Street";
    private const string CHANGED_ADDRESS_2 = "1111 Pine Road";
    private const string CHANGED_ADDRESS_3 = "5555 5th Avenue";

    [Fact]
    public void Test_IsDirtyAndRevertWork()
    {
        Customer customer = new Customer(1, "ABC", ORIGINAL_ADDRESS, 
            "Houston", "TX", "77777");

        // Should not be "dirty", because the initial values have not changed.
        Assert.False(customer.IsDirty);
        Assert.Equal(ORIGINAL_ADDRESS, customer.Address);

        customer.Address = CHANGED_ADDRESS_1;
        customer.SaveCurrentStateToMemento();

        // Should be "dirty".
        Assert.True(customer.IsDirty);
        Assert.Equal(CHANGED_ADDRESS_1, customer.Address);

        customer.Address = CHANGED_ADDRESS_2;
        customer.SaveCurrentStateToMemento();

        // Should be "dirty".
        Assert.True(customer.IsDirty);
        Assert.Equal(CHANGED_ADDRESS_2, customer.Address);

        customer.Address = CHANGED_ADDRESS_3;

        // Should be "dirty".
        Assert.True(customer.IsDirty);
        Assert.Equal(CHANGED_ADDRESS_3, customer.Address);

        // Revert the current change, to latest saved memento.
        customer.RevertToPreviousValues();

        // Should be "dirty".
        Assert.True(customer.IsDirty);
        Assert.Equal(CHANGED_ADDRESS_2, customer.Address);

        // Go back to original values.
        customer.RevertToOriginalValues();

        // Should not be "dirty" after reverting values.
        Assert.False(customer.IsDirty);
        Assert.Equal(ORIGINAL_ADDRESS, customer.Address);
    }
}