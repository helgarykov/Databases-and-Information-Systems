using Data.Models;

namespace Data.IServices;

public interface ITaskReviewService
{
    public IEnumerable<TaskReview> AddReviewViaDapper();
}