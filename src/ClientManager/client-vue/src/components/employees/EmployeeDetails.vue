<template>
  <div class="container-fluid" style="margin-top: 25px;">
    <!-- <b-table striped hover head-variant="dark"></b-table> -->
    <div class="row">
      <div class="col-md-12">
        <div class="table-responsive">
          <table class="table table-striped">
            <thead class="table-dark">
              <tr>
                <th>Employee's Name</th>
                <th>Employee's Email</th>
                <th>Phone #</th>
                <th>Position</th>
                <th>Salary</th>
                <th>Hourly Rate</th>
                <th>Start Date</th>
                <th>End Date</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>{{ employee.firstName }} {{employee.lastName}}</td>
                <td>{{ employee.email }}</td>
                <td>{{ employee.phoneNumber }}</td>
                <td>{{ employee.position }}</td>
                <td>{{ employee.salary }}</td>
                <td>{{ employee.hourlyRate }}</td>
                <td>{{ employee.startDate }}</td>
                <td>{{ employee.endDate}}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>

    <button class="btn btn-info" @click="updateEmployee($employeeId)">Update</button>
  </div>
</template>

<script>
import EmployeeService from "@/services/employee-service";

export default {
  name: "EmployeeDetails",
  data() {
    return {
      employee: {}
    };
  },
  created() {
    EmployeeService.getSingle(this.$router.currentRoute.params.id)
    .then(response => {
        this.employee = response.data;
      }
    );
  },
  methods: {
    updateEmployee(employeeId) {
      this.$router.push({ name: "EmployeeUpdate", params: { id: employeeId } });
      console.log('update', employeeId)
    },
    onUpdateClick() {
      this.$emit('update', this.employee.id)
    }
  }
};
</script>

<style>
</style>
