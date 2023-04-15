namespace e_com_RSEt_API.Models
{
    public class saleComputerDTO
    {
        public int? comId { get; set; }
        public string Mf { get; set; } = string.Empty;
        public string Series { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public string ImagePath = string.Empty;
        public string _ImagePath
        {
            get
            {
                return "http://localhost:5267/api/fileUpload/item-image/" + ImagePath;
                //set the api URL
            }
            set
            {
                ImagePath = value ?? string.Empty;
            }
        }

        public byte[]? Data { get; set; }
    }

    public class seleComputerList
    {
        public List<saleComputerDTO> saleComputerDTOs { get; set; } = new List<saleComputerDTO>();
    }
}

