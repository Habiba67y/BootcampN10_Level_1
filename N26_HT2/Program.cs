using N26_HT2;

var skill1 = new Skill("reading", SkillLevel.Experienced);
var skill2 = new Skill("listening", SkillLevel.Expert);
var skill3 = new Skill("speaking", SkillLevel.Beginner);
var skill4 = new Skill("writening", SkillLevel.Master);
var skill5 = new Skill("programming", SkillLevel.Expert);
var skill6 = new Skill("cooking", SkillLevel.Master);
var skill7 = new Skill("sleeping", SkillLevel.Experienced);
var first = new List<Skill>
{
    skill1, skill2, skill3, skill4, skill5
};
skill3.Level = SkillLevel.Expert;
var second = new List<Skill>
{
    skill6, skill7, skill1, skill2, skill3 
};

Console.WriteLine("First: ");
first.ForEach(Console.WriteLine);
Console.WriteLine("Second: ");
second.ForEach(Console.WriteLine);
Console.WriteLine("Updated: ");
CollectionExtencions.Update(first, second).ToList().ForEach(Console.WriteLine);