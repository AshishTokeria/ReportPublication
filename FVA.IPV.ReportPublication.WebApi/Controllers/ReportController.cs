using Microsoft.AspNetCore.Mvc;
using MediatR;
using FVA.IPV.ReportPublication.Transport.Dto;
using System.Net;
using FVA.IPV.ReportPublication.Provider.Request;

namespace FVA.IPV.ReportPublication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ReportController> _logger;

        public ReportController(IMediator mediator, ILogger<ReportController> logger)
        {
            _mediator = mediator;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [Route("publich-report")]
        public async Task<IActionResult> PublishReportAsync([FromBody] Report report)
        {
            bool success = false;
            try
            {
                _logger.LogInformation($"Web request publich-report started rowcount: {report.RowCount} date: {report.AsOfDate}, site: {report.Site}, label: {report.Label}.");
                success = await _mediator.Send(new PublishReportRequest(report.AsOfDate, report.Site, report.Label, report.RowCount));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new HttpStatusException(HttpStatusCode.BadRequest, ex.Message);
            }
            _logger.LogInformation($"Web request publich-report finished successfully.");
            return Ok(success);
        }

        [HttpPost]
        [Route("upload-report")]
        public async Task<IActionResult> UploadReportAsync([FromBody] Report report)
        {
            int count = 0;
            try
            {
                _logger.LogInformation($"Web request upload-report started date: {report.AsOfDate}, site: {report.Site}, label: {report.Label}.");
                count = await _mediator.Send(new UploadReportRequest(report.AsOfDate, report.Site));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new HttpStatusException(HttpStatusCode.BadRequest, ex.Message);
            }

            _logger.LogInformation($"Web request upload-report finished successfully.");
            return Ok(count);
        }
    }
}
