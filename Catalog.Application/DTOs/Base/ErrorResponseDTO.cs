namespace Catalog.Application.DTOs.Base
{
    public class ErrorResponseDTO : BaseResponseDTO
    {
        public override bool Success { get; } = false;
    }

    public class ErrorResponseDTO<TResponseDTO> : ErrorResponseDTO where TResponseDTO : class
    {
        public TResponseDTO Data { get; set; }

        public ErrorResponseDTO(TResponseDTO data)
        {
            Data = data;
        }
    }
}
