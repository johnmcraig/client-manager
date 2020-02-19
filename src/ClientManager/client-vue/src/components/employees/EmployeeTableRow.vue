<template>
  <tr>
    <td>{{ employee.firstName }} {{ employee.lastName }}</td>
    <td>{{ employee.email }}</td>
    <td>{{ employee.phoneNumber }}</td>
    <td>
      <b-button variant="primary" @click="onDetailsClick">Details</b-button>
    </td>
    <td>
      <b-button variant="success" @click="onUpdateClick">Update</b-button>
    </td>
    <td>
      <b-button variant="danger" @click="onDeleteClick">Delete</b-button>
    </td>
  </tr>
</template>

<script>
export default {
  name: 'employee-table-row',
  props: [ 'employee' ],
  methods: {
    onDetailsClick() {
        this.$emit('details', this.employee.id)
    },
    onUpdateClick() {
      this.$emit('update', this.employee.id)
    },
    onDeleteClick() {
      this.$emit('delete', this.employee.id)
    },
  }
}
</script>

<style>
</style>