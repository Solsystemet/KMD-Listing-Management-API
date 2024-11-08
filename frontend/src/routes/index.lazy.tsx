import { createLazyFileRoute } from "@tanstack/react-router";
import { SurveyTab } from "../components/surveyTab/SurveyTab";

export const Route = createLazyFileRoute("/")({
   component: Index,
});

function Index() {
   const surveyData = [
      {
         date: new Date(),
         company: "Company 1",
         projectName: "Project 1",
         dataProcessor: "Processor 1",
      },
      {
         date: new Date(),
         company: "Company 2",
         projectName: "Project 2",
         dataProcessor: "Processor 2",
      },
      {
         date: new Date(),
         company: "Company 3",
         projectName: "Project 3",
         dataProcessor: "Processor 3",
      },
      {
         date: new Date(),
         company: "Company 4",
         projectName: "Project 4",
         dataProcessor: "Processor 4",
      },
      {
         date: new Date(),
         company: "Company 4",
         projectName: "Project 4",
         dataProcessor: "Processor 4",
      },
   ];

   return (
      <main>
         <SurveyTab children={surveyData} />
      </main>
   );
}
