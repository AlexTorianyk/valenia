using VeritySDK.Protocols.QuestionAnswer;
using VeritySDK.Utils;

namespace Valenia.Verity.Handlers
{
    public class QuestionHandler : BaseHandler
    {
        public QuestionHandler(string relationshipDID, string questionText, string questionDetail, string[] validResponses)
        {
            Handler = CommittedAnswer.v1_0(
                relationshipDID,
                questionText,
                questionDetail,
                validResponses,
                true);
            MessageHandler = (messageName, message) =>
            {
                if ("public-identifier-created".Equals(messageName))
                {
                    var json_identifier = message.GetValue("identifier");
                    var issuerDID = json_identifier["did"];
                    var issuerVerKey = json_identifier["verKey"];
                }
            };
        }
    }
}
