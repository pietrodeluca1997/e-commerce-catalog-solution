namespace Catalog.Application.DTOs.Base
{
    public class SucessResponseDTO : BaseResponseDTO
    {
        public override bool Success { get; } = true;
    }

    public class SucessResponseDTO<TResponseDTO> : SucessResponseDTO where TResponseDTO : class
    {
        public TResponseDTO Data { get; set; }

        public SucessResponseDTO(TResponseDTO data)
        {
            Data = data;
        }
    }
}
