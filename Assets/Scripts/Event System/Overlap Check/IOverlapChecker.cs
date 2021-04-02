public interface IOverlapChecker
{
    bool IsValidTag(string tag);

    void SetOverlapStatus(bool isOverlapping);
    
    bool GetOverlapStatus();
}
