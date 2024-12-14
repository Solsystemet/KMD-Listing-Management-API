import { createFileRoute, useNavigate } from "@tanstack/react-router";

export const Route = createFileRoute("/listing/")({
   component: Index,
});

function Index() {
   const navigate = useNavigate({ from: "/listing" });
   navigate({ to: "/listing/$listingId", params: { listingId: "index" } });
}
