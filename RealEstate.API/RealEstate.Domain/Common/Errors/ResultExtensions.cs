
namespace RealEstate.Domain.Common.Errors
{
    public static class ResultExtensions
    {
        public static Result<(T1, T2)> CombineResults<T1, T2>(Result<T1> result1, Result<T2> result2)
        {
            return result1.Match(
                success1 => result2.Match(
                    success2 => Result<(T1, T2)>.Success((success1, success2)),
                    Result<(T1, T2)>.Failure
                ),
                Result<(T1, T2)>.Failure
            );
        }
        public static Result<(T1, T2, T3)> CombineResults<T1, T2, T3>(Result<T1> result1, Result<T2> result2, Result<T3> result3)
        {
            return result1.Match(
                success1 => result2.Match(
                    success2 => result3.Match(
                        success3 => Result<(T1, T2, T3)>.Success((success1, success2, success3)),
                        Result<(T1, T2, T3)>.Failure
                    ),
                    Result<(T1, T2, T3)>.Failure
                ),
                Result<(T1, T2, T3)>.Failure
            );
        }

        public static Result<(T1, T2, T3, T4)> CombineResults<T1, T2, T3, T4>(Result<T1> result1, Result<T2> result2, Result<T3> result3, Result<T4> result4)
        {
            return result1.Match(
                success1 => result2.Match(
                    success2 => result3.Match(
                        success3 => result4.Match(
                            success4 => Result<(T1, T2, T3, T4)>.Success((success1, success2, success3, success4)),
                            Result<(T1, T2, T3, T4)>.Failure
                        ),
                        Result<(T1, T2, T3, T4)>.Failure
                    ),
                    Result<(T1, T2, T3, T4)>.Failure
                ),
                Result<(T1, T2, T3, T4)>.Failure
            );
        }
        public static Result<(T1, T2, T3, T4, T5)> CombineResults<T1, T2, T3, T4, T5>(Result<T1> result1, Result<T2> result2, Result<T3> result3, Result<T4> result4, Result<T5> result5)
        {
            return result1.Match(
                success1 => result2.Match(
                    success2 => result3.Match(
                        success3 => result4.Match(
                            success4 => result5.Match(
                                success5 => Result<(T1, T2, T3, T4, T5)>.Success((success1, success2, success3, success4, success5)),
                                Result<(T1, T2, T3, T4, T5)>.Failure
                            ),
                            Result<(T1, T2, T3, T4, T5)>.Failure
                        ),
                        Result<(T1, T2, T3, T4, T5)>.Failure
                    ),
                    Result<(T1, T2, T3, T4, T5)>.Failure
                ),
                Result<(T1, T2, T3, T4, T5)>.Failure
            );
        }
        public static Result<(T1, T2, T3, T4, T5, T6)> CombineResults<T1, T2, T3, T4, T5, T6>(Result<T1> result1, Result<T2> result2, Result<T3> result3, Result<T4> result4, Result<T5> result5, Result<T6> result6)
        {
            return result1.Match(
                success1 => result2.Match(
                    success2 => result3.Match(
                        success3 => result4.Match(
                            success4 => result5.Match(
                                success5 => result6.Match(
                                    success6 => Result<(T1, T2, T3, T4, T5, T6)>.Success((success1, success2, success3, success4, success5, success6)),
                                    Result<(T1, T2, T3, T4, T5, T6)>.Failure
                                ),
                                Result<(T1, T2, T3, T4, T5, T6)>.Failure
                            ),
                            Result<(T1, T2, T3, T4, T5, T6)>.Failure
                        ),
                        Result<(T1, T2, T3, T4, T5, T6)>.Failure
                    ),
                    Result<(T1, T2, T3, T4, T5, T6)>.Failure
                ),
                Result<(T1, T2, T3, T4, T5, T6)>.Failure
            );
        }
        public static Result<(T1, T2, T3, T4, T5, T6, T7)> CombineResults<T1, T2, T3, T4, T5, T6, T7>(Result<T1> result1, Result<T2> result2, Result<T3> result3, Result<T4> result4, Result<T5> result5, Result<T6> result6, Result<T7> result7)
        {
            return result1.Match(
                success1 => result2.Match(
                    success2 => result3.Match(
                        success3 => result4.Match(
                            success4 => result5.Match(
                                success5 => result6.Match(
                                    success6 => result7.Match(
                                        success7 => Result<(T1, T2, T3, T4, T5, T6, T7)>.Success((success1, success2, success3, success4, success5, success6, success7)),
                                        Result<(T1, T2, T3, T4, T5, T6, T7)>.Failure
                                    ),
                                    Result<(T1, T2, T3, T4, T5, T6, T7)>.Failure
                                ),
                                Result<(T1, T2, T3, T4, T5, T6, T7)>.Failure
                            ),
                            Result<(T1, T2, T3, T4, T5, T6, T7)>.Failure
                        ),
                        Result<(T1, T2, T3, T4, T5, T6, T7)>.Failure
                    ),
                    Result<(T1, T2, T3, T4, T5, T6, T7)>.Failure
                ),
                Result<(T1, T2, T3, T4, T5, T6, T7)>.Failure
            );
        }
    }
}


