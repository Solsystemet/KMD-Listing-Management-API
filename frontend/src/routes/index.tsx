import { createFileRoute, useNavigate } from "@tanstack/react-router";

export const Route = createFileRoute("/")({
   component: Index,
});

function Index() {
   const navigate = useNavigate({ from: "/" });
   navigate({ to: "/listing/$postId", params: { postId: "index" } });
}