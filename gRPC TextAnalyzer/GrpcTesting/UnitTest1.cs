namespace GrpcTesting;

using GrpcService;
using GrpcService.Services;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using NSubstitute;
using Grpc.Core;
using System.Security.Cryptography.X509Certificates;

public class Tests
{
    
    private ServerCallContext _mockContext;
    private TextAnalysisService tas;
    [SetUp]
    public void Setup()
    {
        tas=new TextAnalysisService();
        //var req=new TextRequest{Name="snake"};
        _mockContext = Substitute.For<ServerCallContext>();
        _mockContext.Method.Returns("/TextAnalysis/TextAnalyze");
        _mockContext.Host.Returns("localhost");
        _mockContext.Deadline.Returns(DateTime.UtcNow.AddMinutes(1));
        _mockContext.RequestHeaders.Returns(new Metadata());
        //_mockContext.ResponseHeaders.Returns(new Metadata());
    }

    [Test]
    public async Task TextAnalyzer_correct_word_count(){

        // Arrange
        var req=new TextRequest{Name="snake"};

        //Act
        var res=await tas.TextAnalyze(req, _mockContext);

        //Assert
        Assert.AreEqual(1,res.Wc);
    
    }
    [Test]
    public async Task TextAnalyzer_throw_exception_when_empty_string(){

        //Arrange
        var req=new TextRequest{Name=" "};
        //var res=await tas.TextAnalyze(req, _mockContext);

        //Act and Assert
        Assert.Throws<ArgumentException>(()=>tas.TextAnalyze(req, _mockContext));   
    }
    [Test]
    public async Task TextAnalyzer_correct_char_count(){

        // Arrange
        var req=new TextRequest{Name="snake"};

        //Act
        var res=await tas.TextAnalyze(req, _mockContext);
       
        //Assert
        Assert.AreEqual(5,res.Cc);
        //Assert.IsFalse(res.IsP); 
    }
    [Test]
    public async Task TextAnalyzer_correct_Palindrome_Check(){
        
        // Arrange
        var req=new TextRequest{Name="snake"};

        //Act
        var res=await tas.TextAnalyze(req, _mockContext);
        
        //Assert
        Assert.IsFalse(res.IsP); 
    }
}