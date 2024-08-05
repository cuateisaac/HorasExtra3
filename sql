ALTER proc [dbo].[SaveNewRequest]
@Operation nchar(10),
@Department nvarchar(50),
@WorkSchedule nvarchar(50),
@ManagerSignature varchar(MAX),
@SupervisorSignature varchar(MAX),
@CreatedDate date,
@UpdatedAt date
as
begin

insert into Request(Operation,Department,WorkSchedule,ManagerSignature,SupervisorSignature,CreatedDate,UpdatedAt)
values(@Operation, @Department, @WorkSchedule, @ManagerSignature, @SupervisorSignature, @CreatedDate, @UpdatedAt)

end
