namespace FitnessMy;

public interface IUser
{
    public string Name { get; }
    public Gender Gender { get; }
    public int Age { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public IActiveStatus ActivityStatus { get; set; }
    public List<Target> Targets { get; }

    public double GetBmr();
    public double GetAmr() => GetBmr() * ActivityStatus.BmrConstant;
}

public interface IActiveStatus
{
    public string ActiveLvl { get; }
    public string ActiveDescription { get; }
    public double BmrConstant { get; }
}

public class Target
{
    public Target(string name)
    {
        Name = name;
    }
    
    public string Name { get; }
}

public enum Gender
{
    Man,
    Woman
}

public class User : IUser
{
    public User(string name, Gender gender, int age, double height, double weight, IActiveStatus activityStatus)
    {
        Name = name;
        Gender = gender;
        Age = age;
        Height = height;
        Weight = weight;
        ActivityStatus = activityStatus;

        Targets = new List<Target>();
    }

    public string Name { get; }
    public Gender Gender { get; }
    public int Age { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public IActiveStatus ActivityStatus { get; set; }
    public List<Target> Targets { get; }
    public double GetBmr()
    {
        return Gender == Gender.Man
            ? 66.47 + 13.75 * Weight + 5.003 * Height - 6.755 * Age
            : 655.1 + 9.563 * Weight + 1.850 * Height - 4.676 * Age;
    }
}
