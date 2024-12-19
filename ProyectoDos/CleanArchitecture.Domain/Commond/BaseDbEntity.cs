namespace CleanArchitecture.Domain.Commond
{
    public abstract class BaseDbEntity
    {
        public int Id { get; set; }           
        public string Type { get; set; }       
        public string Name { get; set; }        
        public string Description { get; set; } 
        public string Data { get; set; }       
        public DateTime Created { get; set; }   
        public string CreatedBy { get; set; } 
        public DateTime? LastModified { get; set; } 
        public string LastModifiedBy { get; set; } 
    }
}
