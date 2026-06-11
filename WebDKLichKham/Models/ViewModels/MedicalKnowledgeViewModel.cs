namespace WebDKLichKham.Models.ViewModels
{
    public class MedicalKnowledgeViewModel
    {
        public string? SearchQuery { get; set; }
        public string? ActiveCategory { get; set; }
        
        public List<SymptomCategory> Categories { get; set; } = new();
        public SymptomDetail? ActiveSymptom { get; set; }
        public List<SymptomDetail> DiseasesInCategory { get; set; } = new();
        public List<Doctor> Doctors { get; set; } = new();
        public List<Article> FeaturedArticles { get; set; } = new();
    }

    public class SymptomCategory
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Icon { get; set; } = "";
    }

    public class SymptomDetail
    {
        public string Id { get; set; } = "";
        public string CategoryId { get; set; } = "";
        public string CategoryName { get; set; } = "";
        public string Name { get; set; } = "";
        public string ShortDescription { get; set; } = "";
        public string Overview { get; set; } = "";
        public List<string> Symptoms { get; set; } = new();
        public List<RelatedDisease> RelatedDiseases { get; set; } = new();
        public List<string> Causes { get; set; } = new();
        public List<string> Impacts { get; set; } = new();
        public List<string> Treatments { get; set; } = new();
        
        public List<ClinicalEvidence> Evidences { get; set; } = new();
        public MinistryGuidelines? MohGuidelines { get; set; }
        public string Prevention { get; set; } = "";
        public string Icon { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }

    public class ClinicalEvidence
    {
        public string Title { get; set; } = "";
        public string Journal { get; set; } = "";
        public string Summary { get; set; } = "";
    }

    public class MinistryGuidelines
    {
        public string DocumentNumber { get; set; } = "";
        public string Title { get; set; } = "";
        public List<string> Recommendations { get; set; } = new();
    }

    public class RelatedDisease
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string DiseaseId { get; set; } = "";
        public string CategoryId { get; set; } = "";
    }

    public class Article
    {
        public string Id { get; set; } = "";
        public string CategoryName { get; set; } = "";
        public string CategoryColor { get; set; } = "";
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string DateString { get; set; } = "";
        public string Content { get; set; } = "";
    }
}
