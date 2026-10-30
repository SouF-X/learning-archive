/* =========================================================
         ✅ Task Manager (IndexedDB) — Beginner Friendly Comments
         =========================================================

         ✅ What this app does:
         1️⃣ Stores tasks in IndexedDB (browser database)
         2️⃣ Reads tasks on startup (so refresh does NOT lose data)
         3️⃣ Lets you: Add / Toggle Done / Delete / Clear All
         4️⃣ Lets you: Filter (All/Pending/Done) + Search
      */

/* =========================================================
         ✅ 1) DOM References (UI elements)
         ---------------------------------------------------------
         We store all important elements in one object (UI)
         so we can access them easily everywhere.
      ========================================================= */
const UI = {
  loading: document.getElementById("loading"), // spinner container
  error: document.getElementById("error"), // error message container
  toast: document.getElementById("toast"), // toast popup

  stats: document.getElementById("stats"), // stats text (Total/Pending/Done)
  shown: document.getElementById("shown"), // how many tasks are shown after filter/search

  filters: document.getElementById("filters"), // filters buttons container
  search: document.getElementById("search"), // search input

  title: document.getElementById("title"), // add form title input
  desc: document.getElementById("desc"), // add form description textarea
  btnAdd: document.getElementById("btnAdd"), // add task button
  btnReset: document.getElementById("btnReset"), // reset form button

  btnSeed: document.getElementById("btnSeed"), // seed demo tasks
  btnClearAll: document.getElementById("btnClearAll"), // clear all tasks

  list: document.getElementById("list"), // tasks container (cards go here)
};

/* =========================================================
         ✅ 2) App State
         ---------------------------------------------------------
         db            → the opened IndexedDB database instance
         tasks         → cached in-memory list of tasks (render reads from here)
         currentFilter → "all" | "pending" | "done"
      ========================================================= */
let db = null;
let tasks = [];
let currentFilter = "all";

/* =========================================================
         ✅ 3) UI Helpers
      ========================================================= */

// ✅ Toast: small popup message (success info, etc.)
function showToast(message) {
  UI.toast.textContent = message;
  UI.toast.style.display = "block";
  setTimeout(() => (UI.toast.style.display = "none"), 2200);
}

// ✅ Loading: show spinner and disable main actions to prevent double clicks
function setLoading(isLoading) {
  UI.loading.style.display = isLoading ? "flex" : "none";
  UI.btnAdd.disabled = isLoading;
  UI.btnSeed.disabled = isLoading;
  UI.btnClearAll.disabled = isLoading;
}

// ✅ Error: show a styled error box
function setError(message) {
  UI.error.textContent = message || "";
  UI.error.style.display = message ? "block" : "none";
}

// ✅ Escape text before putting it into innerHTML
// This prevents user text from being interpreted as real HTML.
function esc(s) {
  return String(s ?? "")
    .replaceAll("&", "&amp;")
    .replaceAll("<", "&lt;")
    .replaceAll(">", "&gt;")
    .replaceAll('"', "&quot;")
    .replaceAll("'", "&#039;");
}

// ✅ Convert timestamp into readable date/time
function formatDate(ms) {
  return new Date(ms).toLocaleString();
}

/* =========================================================
         ✅ 4) IndexedDB - Open DB + Upgrade
         ---------------------------------------------------------
         IndexedDB is event-based, so we wrap it in a Promise
         to use async/await cleanly.
      ========================================================= */
function openDB() {
  return new Promise((resolve, reject) => {
    // ✅ Open "TaskDB" version 1
    const request = indexedDB.open("TaskDB", 1);

    // ✅ onupgradeneeded runs only:
    // - first time creating the DB
    // - OR when you increase the version number
    request.onupgradeneeded = () => {
      const db = request.result;

      // ✅ Create store "tasks"
      // keyPath: "id" means each task has an "id"
      // autoIncrement: true means IDs generated automatically (1,2,3,...)
      const store = db.createObjectStore("tasks", {
        keyPath: "id",
        autoIncrement: true,
      });

      // ✅ Indexes (optional but useful for searching/sorting later)
      store.createIndex("status", "status", { unique: false });
      store.createIndex("createdAt", "createdAt", { unique: false });
    };

    // ✅ Success: return the opened DB
    request.onsuccess = () => resolve(request.result);

    // ✅ Failure: return the error
    request.onerror = () =>
      reject(request.error || new Error("Failed to open IndexedDB"));
  });
}
