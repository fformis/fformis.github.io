using System.Globalization;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks.Dataflow;

var files = Directory.GetFiles("_posts", "*.md");
Dictionary<string, List<Post>> tagsCloud = new Dictionary<string, List<Post>>();
Dictionary<string, int> tagsCount = new Dictionary<string, int>();
Dictionary<string, string> tagsFiles = new Dictionary<string, string>();
Dictionary<string, string> tagsTitles = new Dictionary<string, string>();
foreach (var file in files)
{
	var postLines = File.ReadLines(file).ToArray();
	var tags = postLines.SingleOrDefault(line => line.StartsWith("tags"));
	var tagFile = postLines.SingleOrDefault(line => line.StartsWith("tagFile:"));
	if (tags != null)
	{

		Post post = new Post()
		{
			Title = postLines.SingleOrDefault(line => line.StartsWith("title:"))
			 	?.Replace("title:", "")
				?.Trim(),
			Excerpt = postLines.SingleOrDefault(line => line.StartsWith("excerpt:"))
			 	?.Replace("excerpt:", "")
				?.Trim(),
			Parts = postLines.SingleOrDefault(line => line.StartsWith("parts:"))
			 	?.Replace("parts:", "")
				?.Trim(),
			File = file,
		};

		var splitted = tags
		.Replace("tags: [", "")
		.Replace("]", "")
		.Split(',');
		var splittedFiles = tagFile
		.Replace("tagFile: [", "")
		.Replace("]", "")
		.Split(',');
		int index = 0;
		foreach (var tag in splitted)
		{

			var key = tag.Trim().Replace(" ", "-").Replace(".", "").Replace("\"", "");
			tagsCloud.TryAdd(key, []);
			tagsCount.TryAdd(key, 0);
			tagsCloud[key].Add(post);
			tagsCount[key]++;
			tagsFiles.TryAdd(key, splittedFiles[index].Trim());
			tagsTitles.TryAdd(key, tag);
			index++;
		}
	}
}

List<string> tagsLi = new List<string>();
foreach (var tag in tagsCloud.Keys)
{
	StringBuilder stringBuilder = new StringBuilder();
	stringBuilder.AppendLine("---");
	stringBuilder.AppendLine("layout: tags");
	stringBuilder.AppendLine($"title: {tagsTitles[tag]}");
	stringBuilder.AppendLine("posts: [");
	stringBuilder.AppendLine(string.Join(',', tagsCloud[tag].Select(x => x.GetInfo()).ToArray()));
	stringBuilder.AppendLine("]");
	stringBuilder.AppendLine("---");

	string tagNormalizada = tag.Normalize(NormalizationForm.FormD);
	StringBuilder sb = new StringBuilder();
	foreach (var c in tagNormalizada)
	{
		if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
		{
			sb.Append(c);
		}
	}

	var tagAddress = sb.ToString().Normalize(NormalizationForm.FormC).ToLower();

	Random rand = new Random();
	int index = rand.Next(2,8);
	//tagsLi.Add($"<li><a data-weight='{(tagsCount[tag] > 10 ? 9 : tagsCount[tag])}' href='/tags/{tagsFiles[tag]}'>{tag}</a></li>");
	tagsLi.Add($"<li><a data-weight='{index}' href='/tags/{tagsFiles[tag]}'>{tagsTitles[tag]}</a></li>");

	File.WriteAllText($"E:\\fformis\\blog\\blog-codando-pro\\tags\\{tagsFiles[tag]}.md", stringBuilder.ToString());
}

StringBuilder sbLi = new StringBuilder();
sbLi.AppendLine("<div class=\"cloud-wrapper\" >");
sbLi.AppendLine("	<ul class=\"cloud\" role=\"navigation\" aria-label=\"Webdev tag cloud\">");
tagsLi.ForEach(li => sbLi.AppendLine("		" + li));
sbLi.AppendLine("	</ul>");
sbLi.AppendLine("</div>");

File.WriteAllText($"E:\\fformis\\blog\\blog-codando-pro\\_includes\\tags.html", sbLi.ToString());


public class Post
{
	public string? Title { get; set; }
	public string? Parts { get; set; }
	public string? Excerpt { get; set; }
	public string? File { get; set; }

	public string GetInfo()
	{
		return "{" + @$"title: {Title}, parts: {Parts}, excerpt: {Excerpt}, url: {Url()}" + "}";
	}

	private string Url()
	{
		return $"/{File?[7..11]}/{File?[12..14]}/{File?[18..(File.Length - 3)]}";
	}
}