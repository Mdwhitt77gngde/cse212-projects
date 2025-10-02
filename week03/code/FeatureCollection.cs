public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // FeatureCollection.cs
    public string Type { get; set; }
    public Feature[] Features { get; set; }
}

public class Feature
{
    public string Type { get; set; }
    public Properties Properties { get; set; }
    // geometry / id not required for this assignment
}

public class Properties
{
    // mag is a number that can be null
    public double? Mag { get; set; }
    public string Place { get; set; }
    // Create additional classes as necessary
}