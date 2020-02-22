<template>
  <div>
    <header>
      <h1
        style="text-align: center;margin-top: auto; font-weight: 600; font-size: 40px;"
      >Client Manager</h1>
      <h5 style="text-align: center;">A demonstration of ASP.Net Core 3.1 and Vue.js</h5>
    </header>

    <div class="card">
      <div class="card-body">
        <h4 class="card-title">Add Clients to the Database</h4>
        <hr />
        <p class="card-text">
          Navigate to a form entry page to add clients to the database using the
          link provided below:
        </p>
        <router-link
          class="btn btn-sm btn-primary card-link"
          to="/employee/form"
        >Go to the Entry Form</router-link>
      </div>
    </div>

    <div class="card">
      <div class="card-body">
        <h4 class="card-title">View List of Current Clients</h4>
        <hr />
        <p class="card-text">
          Navigate to see a page displaying a list of all existing clients using the link provided
          below:
        </p>
        <router-link
          class="btn btn-sm btn-primary card-link"
          to="/employee/table"
        >Go to the Current List</router-link>
      </div>
    </div>

    <div class="card">
      <div class="card-body">
        <h4 class="card-title">Demo Code on Github</h4>
        <hr />
        <p
          class="card-text"
        >Learn how to setup this application web page on the active Github page by the author and developer:</p>
        <a
          class="btn btn-sm btn-primary card-link"
          href="https://github.com/johnmcraig/employee-list"
        >Go to Github Page</a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Home",
  components: {}
};
</script>

<style scoped>
.card {
  margin: 2rem;
}

header {
  background-color: #3274d3; 
  color: #fff;
  min-height: 225px;
  align-items: center;
}

header h1 {
  margin-top: 2rem;
  margin-bottom: 2rem;
}
</style>