/**
 * Copies the contents of a card body into the clipboard as an HTML table
 * @param {string} cardBodyId - The id of the card body element to copy
 * @param {boolean} copyHeaders - Whether to include the header row (labels)
 * @returns {boolean} true if copy succeeded, false otherwise
 */
export async function copyCardBodyAsTable(cardBodyId, copyHeaders = true) {
    const cardBody = document.getElementById(cardBodyId)
    if (!cardBody) {
        console.error(`Card body with id '${cardBodyId}' not found`)
        return false
    }

    const cols = cardBody.querySelectorAll('.col')
    if (cols.length === 0) {
        console.warn('No .col elements found in card body')
        return false
    }

    let headerHtml = ''
    let rowHtml = '<tr>'

    cols.forEach(col => {
        const label = col.querySelector('span')?.innerText ?? ''
        const value = col.querySelector('p')?.innerText ?? ''

        if (copyHeaders) {
            headerHtml += `<th>${label}</th>`
        }
        rowHtml += `<td>${value}</td>`
    })

    rowHtml += '</tr>'

    let tableHtml = '<table>'
    if (copyHeaders) {
        tableHtml += `<tr>${headerHtml}</tr>`
    }
    tableHtml += rowHtml + '</table>'

    try {
        const blobHtml = new Blob([tableHtml], { type: 'text/html' })
        const blobText = new Blob([tableHtml], { type: 'text/plain' })
        const item = new ClipboardItem({ 'text/html': blobHtml, 'text/plain': blobText })
        await navigator.clipboard.write([item])
        return true
    } catch (err) {
        return false
    }
}
