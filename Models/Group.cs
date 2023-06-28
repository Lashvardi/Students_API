namespace Students_APP.Models;

public class Group
{
    public int Id { get; set; }
    
    public string GroupName { get; set; }
    
    
    // Navigation
    public ICollection<StudentGroup> StudentGroups { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    
    public static string GenerateGroupName()
    {
        string[] chars = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        Random rand = new Random();
        string part1 = chars[rand.Next(chars.Length)] + chars[rand.Next(chars.Length)];
        string part2 = chars[rand.Next(chars.Length)] + chars[rand.Next(chars.Length)];
        string part3 = rand.Next(10, 99).ToString("D2");
        return $"{part1}-{part2}-{part3}";
    }



}

